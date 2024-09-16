using Libly.Data;
using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        public ActionResult OnGet(int id)
        {
            // Retrieve the book to be deleted
            Book = BooksData.Get(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost(int id)
        {
            //ask the service code to delete this
            BooksData.Delete(id);   

            //return back to index
            return RedirectToPage("./Index");    
        }
    }
}
