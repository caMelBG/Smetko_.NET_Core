namespace Kitchen.Models
{
    public class MealProduct
    {
        public int MealProductId { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public double Quantity { get; set; }
    }
}
