using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MyWebTest.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public Book Book { get; set; }
     
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
