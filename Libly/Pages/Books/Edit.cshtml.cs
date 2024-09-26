using Libly.Core.Data;
using Libly.Core.Models;
using Libly.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Libly.Pages.Books
{
    public class EditModel : PageModel  //Inheritance (reuse)
    {
        private readonly BooksContext _context;

        [BindProperty]
        public BookViewModel BookVM { get; set; } //property
        public List<SelectListItem> CategoryOptions { get; set; }
        public EditModel(BooksContext context)
        {
            _context = context;
        }        
        public ActionResult OnGet(int id)
        {            
            Book book = _context.Books.Find(id);
            
            if (book == null)
            {
                return NotFound(); //404 error (standard HTML)
            }

            // Populate the view model
            BookVM = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Dop = book.Dop,
                CategoryId = book.CategoryId
            };

            PopulateDropDown();

            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDown();
                return Page();
            }            

            //bookToUpdate is now being tracked by EF
            Book bookToUpdate = _context.Books.Find(BookVM.Id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            // Update the book with the new values
            bookToUpdate.Title = BookVM.Title;
            bookToUpdate.Dop = BookVM.Dop;
            bookToUpdate.CategoryId = BookVM.CategoryId;

            bookToUpdate.ModifiedOn = DateTime.Now;

            //BooksData.Update(bookToUpdate);

            try
            {
                //All changes to bookToUpdate will be saved to the db by the EF
                //which means EF has to figure out the specific update SQL queries                
                _context.SaveChanges();
            }          

            catch (DbUpdateConcurrencyException)
            {
                //same entry being updated by atleast two people
            }
           
            catch (DbUpdateException)
            {
                //violated the database constraints
            }
            catch (Exception)
            {
                //Any other error not caught before
                ModelState.AddModelError("Save Error", "Something din go as expected, a ticket has been raised");
                PopulateDropDown();
            }

            return RedirectToPage("./Index");
        }

        private void PopulateDropDown()
        {                        
            //functional programing
            CategoryOptions = _context
                                .Categories
                                .Select(c => new SelectListItem
                                    {
                                        Value = c.Id.ToString(),
                                        Text = c.Name
                                    })
                                .OrderBy(c => c.Text)  
                                .ToList();
        }
    }
}
