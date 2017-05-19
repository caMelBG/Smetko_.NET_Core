using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Product
    {
        private ICollection<DishProduct> _meals;

        public Product()
        {
            this._meals = new HashSet<DishProduct>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public ICollection<DishProduct> Meals { get; set; }
    }
}
