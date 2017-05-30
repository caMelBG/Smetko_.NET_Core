using Kitchen.Data;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderMeals)
                    .ThenInclude(om => om.Meal)
                .ToListAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var order = new Order()
            {
                OrderMeals = _context.Meals
                    .Include(m => m.Category)
                    .Where(m => m.IsActive)
                    .Select(m => new OrderMeal()
                    {
                        Meal = m,
                        MealId = m.Id
                    })
                    .ToList()
            };
            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (!order.OrderMeals.Any(om => om.IsSelected))
            {
                ModelState.AddModelError("", $"You haven't selected any meal.");
            }
            else
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var selectedMeal = order.OrderMeals
                            .Where(om => om.IsSelected)
                            .ToList();
                        order.OrderMeals = selectedMeal;
                        foreach (var orderMeal in order.OrderMeals)
                        {
                            var mealFromDb = await _context.Meals
                                .Include(m => m.MealProducts)
                                    .ThenInclude(ml => ml.Product)
                                 .Include(m => m.Category)
                                .FirstOrDefaultAsync(m => m.Id == orderMeal.MealId);
                            if (mealFromDb != null)
                            {
                                order.Price += (orderMeal.Quantity * mealFromDb.Price);
                                foreach (var mealProduct in mealFromDb.MealProducts)
                                {
                                    var product = mealProduct.Product;
                                    if ((mealProduct.Quantity * orderMeal.Quantity) > product.Quantity)
                                    {
                                        ModelState.AddModelError("",
                                            $"There is no enough \"{product.ProductName}\" to" +
                                            $" make {orderMeal.Quantity} {mealFromDb.Name}");
                                    }
                                    else
                                    {
                                        product.Quantity -= (mealProduct.Quantity * orderMeal.Quantity);
                                    }
                                }
                            }
                        }

                        if (ModelState.IsValid)
                        {
                            _context.Add(order);
                            dbContextTransaction.Commit();
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }

            var newOrder = new Order()
            {
                OrderMeals = _context.Meals
                    .Include(m => m.Category)
                    .Where(m => m.IsActive)
                    .Select(m => new OrderMeal()
                    {
                        Meal = m,
                        MealId = m.Id
                    })
                    .ToList()
            };
            return View(newOrder);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
