namespace BookStoreApi.Entities
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }

        public List<Category>? Categories { get; set; }

    }
}
