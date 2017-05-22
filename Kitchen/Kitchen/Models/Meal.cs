using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Meal
    {
        private ICollection<MealProduct> _products;

        public Meal()
        {
            this.IsActive = true;
            this._products = new HashSet<MealProduct>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Meal name")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }

        public double Weight { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<MealProduct> MealProducts
        {
            get { return this._products; }
            set { this._products = value; }
        }
    }
}
