using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MyWebTest.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This filed name is required")]
        [DisplayName("CategoryName")]
        public string CategoryName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This filed name is required")]
        [DisplayName("Description")]
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
