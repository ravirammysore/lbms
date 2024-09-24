using Libly.Data;
using Libly.Models;
using Libly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libly.Pages.Books
{
    public class EditModel : PageModel  //Inheritance (reuse)
    {
        [BindProperty]
        public BookViewModel BookVM { get; set; } //property
        public List<SelectListItem> CategoryOptions { get; set; }

        public ActionResult OnGet(int id)
        {
            //Book book = BooksData.Get(id);
            
            var context = new BooksContext();
            Book book = context.Books.Find(id);

            //Book book = context.Books.FirstOrDefault(b=>b.Id == id);

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

            // Load the book from the in-memory collection
            //Book bookToUpdate = BooksData.Get(BookVM.Id);
            var context = new BooksContext();

            //bookToUpdate is now being tracked by EF
            Book bookToUpdate = context.Books.Find(BookVM.Id);

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

            //All changes to bookToUpdate will be saved to the db by the EF
            //which means EF has to figure out the specific update SQL queries
            context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private void PopulateDropDown()
        {
            var context = new BooksContext(); 
            
            //functional programing
            CategoryOptions = context
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
