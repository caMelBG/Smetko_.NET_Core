using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Category
    {
        private ICollection<Meal> meals;

        public Category()
        {
            this.meals = new HashSet<Meal>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public ICollection<Meal> Meals
        {
            get { return this.meals; }
            set { this.meals = value; }
        }
    }
}
