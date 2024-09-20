using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Models;
using Libly.Data;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books 
{
    public class IndexModel : PageModel 
    {        
        public List<Book> books; //Collections
        public void OnGet() 
        {
            //books = BooksData.GetAll(); //fetch this stuff froma real db or a service later!

            var context = new BooksContext();

            //Explicit loading (we specify which related entities we need)
            books = context.Books
                .Include(b=>b.Category)                                
                .ToList();

            //The navigation property (related entity) is NOT loaded untill you ask for it!
            //In EF classic this would still work out of the box!
            books = context.Books.ToList();
        }      
    }    
}
