using Libly.Data;
using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        public ActionResult OnGet(int id)
        {
            // Retrieve the book to be deleted
            //Book = BooksData.Get(id);
            
            var context = new BooksContext();
            Book = context.Books
                .Include(b=>b.Category)
                .SingleOrDefault(b=>b.Id == id);    

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost(int id)
        {
            //ask the service code to delete this
            //BooksData.Delete(id);   

            var context = new BooksContext();
            //Removes it from DbSet only
            context.Books.Remove(Book);
            
            //never call this in a loop
            context.SaveChanges();

            //return back to index
            return RedirectToPage("./Index");    
        }
    }
}
