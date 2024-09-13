﻿namespace Libly.Models
{
    public class Book
    {
        //attributes ----> properties
        public int Id { get; set; } //auto-implemented property
        public string Title { get; set; } //let us not have method just for getting and setting
        public string Category { get; set; } //CamelCase
        public DateTime Dop { get; set; }
        public DateTime CreatedOn { get; private set; } //01-01-1000
        public DateTime? ModifiedOn { get; set; }

        public Book()
        {
            Console.WriteLine("");
        }

        public Book(int id, string title, string category, DateTime dop)
        {
            Id = id;
            Title = title;
            Category = category;
            Dop = dop;
            CreatedOn = DateTime.Now;
        }
    }
}
