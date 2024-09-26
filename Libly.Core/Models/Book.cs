using System;
using System.ComponentModel.DataAnnotations;

namespace Libly.Core.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dop { get; set; }

        // Navigation property to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Parameterless constructor
        public Book() : base()
        {
        }

        // Parameterized constructor
        public Book(int id, string title, DateTime dop, int categoryId) : this()
        {
            Id = id;
            Title = title;
            Dop = dop;
            CategoryId = categoryId;
        }

        public bool IsNew()
        {
           //ternary operator and i have also used a compound expression
            return (DateTime.Now - Dop).TotalDays <= 60 ? true : false;  
        }
    }
}
