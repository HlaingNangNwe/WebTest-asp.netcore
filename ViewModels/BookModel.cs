using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebTest.Models;

namespace MyWebTest.ViewModels
{
    public class BookModel
    {
        private List<Book> books;
        public Book Book { get; set; }
        public BookModel()
        {
           
        }

        public List<Book> findAll()
        {
            return books;
        }

        public Book find(int id)
        {
            return books.Where(b => b.bookId == id).FirstOrDefault();
        }
    }
}
