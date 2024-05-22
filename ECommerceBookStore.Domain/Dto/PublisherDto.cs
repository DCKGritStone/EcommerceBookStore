using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBookStore.Domain.Dto
{
    public class PublisherDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BookId { get; set; }
        public long Price { get; set; }
        public long Stock { get; set; }
        public long Payment { get; set; }
    }
}
