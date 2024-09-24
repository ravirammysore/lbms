using Libly.Models;
using Microsoft.EntityFrameworkCore;

namespace Libly.Data
{
    //An object of this will be used to fetch or save entities from the DB
    public class BooksContext : DbContext
    {              
        //This is an in-memory collection of the data in Books table
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }       
    }
}
