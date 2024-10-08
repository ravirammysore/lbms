﻿using Libly.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Libly.Core.Data;

//An object of this will be used to fetch or save entities from the DB
public class BooksContext : DbContext
{              
    //This is an in-memory collection of the data in Books table
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BooksContext(DbContextOptions<BooksContext> options) : base(options)
    {
        //this constructor is needed by the DI framework to instatiate an object for us
    }        
}
