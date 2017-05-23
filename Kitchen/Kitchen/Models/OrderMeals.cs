using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Models
{
    public class OrderMeal
    {
        public OrderMeal()
        {
            this.IsSelected = false;
            this.Quantity = 1;
        }

        public int OrderMealId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
