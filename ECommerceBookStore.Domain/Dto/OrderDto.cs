namespace ECommerceBookStore.Domain.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public string? Quantity { get; set; }
        public long TotalPrice { get; set; }

    }
}
