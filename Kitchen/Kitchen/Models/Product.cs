using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class Product
    {
        private ICollection<MealProduct> _meals;

        public Product()
        {
            this._meals = new HashSet<MealProduct>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public double Quantity { get; set; }

        [Display(Name = "Quantity Type")]
        public QuantityType Type { get; set; }

        public ICollection<MealProduct> Meals { get; set; }
    }
}
