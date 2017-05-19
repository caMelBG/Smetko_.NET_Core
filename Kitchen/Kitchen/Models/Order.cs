using System.Collections.Generic;

namespace Kitchen.Models
{
    public class Order
    {
        private ICollection<Dish> _meals;

        public Order()
        {
            this._meals = new HashSet<Dish>();
        }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public ICollection<Dish> Meals
        {
            get { return this._meals; }
            set { this._meals = value; }
        }
    }
}
