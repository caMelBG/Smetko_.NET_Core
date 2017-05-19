namespace Kitchen.Models
{
    public class DishProduct
    {
        public int DishProductId { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
