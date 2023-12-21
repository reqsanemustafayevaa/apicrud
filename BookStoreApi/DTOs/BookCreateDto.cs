namespace BookStoreApi.DTOs
{
    public class BookCreateDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Double Price { get; set; }
        public double Costprice { get; set; }

    }
}
