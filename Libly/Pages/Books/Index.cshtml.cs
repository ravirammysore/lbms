using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libly.Models;
using Libly.Data;

namespace Libly.Pages.Books 
{
    public class IndexModel : PageModel 
    {        
        public List<Book> books; //Collections
        public void OnGet() 
        {
            books = BooksData.GetAll(); //fetch this stuff froma real db or a service later!
        }      
    }    
}
