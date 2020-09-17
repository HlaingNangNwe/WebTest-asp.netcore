using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebTest.Models;
using Microsoft.EntityFrameworkCore;


namespace MyWebTest.Models
{
    public class MyWebTestContext : DbContext
    {
        public MyWebTestContext(DbContextOptions<MyWebTestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        

    }
}
