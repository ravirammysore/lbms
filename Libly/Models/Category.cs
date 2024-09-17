namespace Libly.Models
{
    public class Category: BaseModel
    {        
        public string Name { get; set; }  // ""        
        
        //Navigation property (true way of doing OOP)
        public List<Book> Books { get; set; }  //reference (null)

        // Parameterless constructor
        public Category() : base()
        {            
            //We now have a list of books which empty (initialized)
            Books = new List<Book>();
        }

        // Parameterized constructor
        public Category(int id, string name): this()
        {
            Id = id;
            Name = name;            
        }      
    }
}
