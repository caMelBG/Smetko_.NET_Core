using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Category
    {
        [Required]
        public string Name { get; set; }

        [Key]
        public int MealId { get; set; }

        public Meal Meal { get; set; }
    }
}
