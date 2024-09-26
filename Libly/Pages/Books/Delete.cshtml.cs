using Libly.Core.Data;
using Libly.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly BooksContext _context;

        [BindProperty]
        public Book Book { get; set; }
        
        public DeleteModel(BooksContext context)
        {
            _context = context;
        }
        public ActionResult OnGet(int id)
        {
            // Retrieve the book to be deleted
            //Book = BooksData.Get(id);
                        
            Book = _context.Books
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
            //Removes it from DbSet only
            _context.Books.Remove(Book);
            
            //never call this in a loop
            _context.SaveChanges();

            //return back to index
            return RedirectToPage("./Index");    
        }
    }
}
