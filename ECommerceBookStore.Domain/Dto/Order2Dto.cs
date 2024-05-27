namespace ECommerceBookStore.Domain.Dto
{
    public class Order2Dto
    {
        public int LoginId { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public string? Quantity { get; set; }
        public long TotalPrice { get; set; }
    }
}
