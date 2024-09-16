using System.ComponentModel.DataAnnotations;

namespace Libly.Models
{
    public class Book
    {
        //attributes ----> properties
        public int Id { get; set; } //auto-implemented property
        public string Title { get; set; } //let us not have method just for getting and setting
        public string Category { get; set; } //CamelCase

        [DataType(DataType.Date)]
        public DateTime Dop { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ModifiedOn { get; set; } //nullables (do not know it)

        public Book()
        {
            CreatedOn = DateTime.Now;
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
