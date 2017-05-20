using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models.MealViewModels
{
    public class CreateMealViewModel
    {
        private ICollection<MealProduct> _products;

        public CreateMealViewModel()
        {
            this._products = new HashSet<MealProduct>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Weight { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public ICollection<MealProduct> Products
        {
            get { return this._products; }
            set { this._products = value; }
        }
    }
}
