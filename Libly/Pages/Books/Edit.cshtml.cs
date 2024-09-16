using Libly.Data;
using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{
    public class EditModel : PageModel  //Inheritance (reuse)
    { 
        [BindProperty]
        public Book BookToUpdate { get; set; } //property
        public ActionResult OnGet(int id)
        {                        
            BookToUpdate = BooksData.Get(id);

            //todo: handle the case where we did not find the book
            if(BookToUpdate == null)
            {
                return NotFound(); //404 error (standard HTML)
            }   
            
            return Page();

        }

        public ActionResult OnPost() 
        {
            //todo: we validate, if failed we return back the same page

            BooksData.Update(BookToUpdate);
            
            return RedirectToPage("./Index");
        }
    }
}
