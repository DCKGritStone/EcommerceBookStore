namespace ECommerceBookStore.Domain.Dto

{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }

    }
}
