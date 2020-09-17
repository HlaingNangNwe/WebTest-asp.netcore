using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MyWebTest.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This filed name is required")]
        [DisplayName("Book Title")]
        public string Name { get; set; }

        internal static Book FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This filed name is required")]
        [DisplayName("Author")]
        public string Author { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Price")]
        public decimal Price { get; set; }



        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
