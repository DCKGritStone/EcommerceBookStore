using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceBookStore.Domain.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }

    }
}
