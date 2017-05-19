using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Category
    {
        [Required]
        public string Name { get; set; }

        [Key]
        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}
