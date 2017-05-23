using System.Collections.Generic;

namespace Kitchen.Models
{
    public class Order
    {
        private ICollection<OrderMeal> _orderMeals;

        public Order()
        {
            this._orderMeals = new HashSet<OrderMeal>();
        }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderMeal> OrderMeals
        {
            get { return this._orderMeals; }
            set { this._orderMeals = value; }
        }
    }
}
