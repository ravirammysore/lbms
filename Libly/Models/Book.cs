using System.ComponentModel.DataAnnotations;

namespace Libly.Models
{
    public class Book : BaseModel
    {
        //attributes ----> properties        
        public string Title { get; set; } //let us not have method just for getting and setting
        public int CategoryId { get; set; }
        public Category Category { get; set; } //Navigation Property 

        [DataType(DataType.Date)]
        public DateTime Dop { get; set; }        

        public Book() : base()
        {
          //Have to be excuted 
        }

        public Book(int id, string title, int categoryId, DateTime dop): this()
        {
            Id = id;
            Title = title;
            CategoryId = categoryId;
            Dop = dop;            
        }
    }
}
