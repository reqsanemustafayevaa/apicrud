namespace BookStoreApi.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public Book? Book { get; set; }
        public int BookId { get; set; }
    }
}
