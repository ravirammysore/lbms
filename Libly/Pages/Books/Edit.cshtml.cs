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
            Book book = BooksData.Get(id);

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
                return PopulateDropDown();
            }

            // Load the book from the in-memory collection
            Book bookToUpdate = BooksData.Get(BookVM.Id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            // Update the book with the new values
            bookToUpdate.Title = BookVM.Title;
            bookToUpdate.Dop = BookVM.Dop;
            bookToUpdate.CategoryId = BookVM.CategoryId;

            bookToUpdate.ModifiedOn = DateTime.Now;

            BooksData.Update(bookToUpdate);

            return RedirectToPage("./Index");
        }

        private ActionResult PopulateDropDown()
        {
            // Reload the category options if validation fails
            CategoryOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Fiction" },
                    new SelectListItem { Value = "2", Text = "Science Fiction" }
                };
            return Page();
        }
    }
}
