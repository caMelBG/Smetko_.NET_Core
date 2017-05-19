using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Dish
    {
        private ICollection<DishProduct> _products;

        public Dish()
        {
            this.IsActive = true;
            this._products = new HashSet<DishProduct>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public double Weight { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<DishProduct> Products
        {
            get { return this._products; }
            set { this._products = value; }
        }
    }
}
