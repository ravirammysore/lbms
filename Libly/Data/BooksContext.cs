using Libly.Models;
using Microsoft.EntityFrameworkCore;

namespace Libly.Data
{
    //An object of this will be used to fetch or save entities from the DB
    public class BooksContext : DbContext
    {
        string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        
        //This is an in-memory collection of the data in Books table
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
