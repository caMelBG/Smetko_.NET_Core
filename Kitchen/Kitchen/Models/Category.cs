using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Category
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Key]
        public int MealId { get; set; }

        public Meal Meal { get; set; }
    }
}
