using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models.MealViewModels
{
    public class DetailsMealViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
