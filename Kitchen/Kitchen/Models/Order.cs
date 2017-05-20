using System.Collections.Generic;

namespace Kitchen.Models
{
    public class Order
    {
        private ICollection<Meal> _meals;

        public Order()
        {
            this._meals = new HashSet<Meal>();
        }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public ICollection<Meal> Meals
        {
            get { return this._meals; }
            set { this._meals = value; }
        }
    }
}
