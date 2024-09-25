using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Models;
using Libly.Data;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books 
{
    public class IndexModel : PageModel 
    {
        private readonly BooksContext _context;

        public List<Book> books; //Collections
        public IndexModel(BooksContext context)
        {
            throw new Exception("Major error!");
            _context = context;
        }        
        public void OnGet() 
        {            
            //In EF Core, the navigation property (related entity) is NOT loaded untill you ask for it!
            //In EF classic this would still work out of the box!
            //books = _context.Books.ToList();

            //Explicit loading (we specify which related entities we need)
            books = _context.Books
                .Include(b=>b.Category)                                
                .ToList();            
        }      
    }    
}
