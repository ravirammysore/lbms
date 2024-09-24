using Libly.Data;
using Libly.Models;
using Libly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty] //Devs had to manually process the body
        public BookViewModel BookVM { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }

        public void OnGet()
        {
            PopulateDropdown();
        }

        //This is also invoked auto when the server receives a POST request from the client
        public ActionResult OnPost()
        {
            //Validate the book 
            if (!ModelState.IsValid)
            {
                PopulateDropdown();
                return Page();
            }

            //mapping from the VM to the actual model
            //Auto-mapper
            var Book = new Book()
            {
                Id = BookVM.Id,
                Title = BookVM.Title,
                Dop = BookVM.Dop,
                CategoryId = BookVM.CategoryId,
            };

            //BooksData.Create(Book); //upto the data-service 
            var context = new BooksContext();
            context.Books.Add(Book);    // we have only added the new book to in-memory DbSet
            context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private void PopulateDropdown()
        {
            var context = new BooksContext();
            var selectListItems = new List<SelectListItem>();

            foreach(var category in context.Categories)
            {
                var selectListItem = new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                };
                selectListItems.Add(selectListItem);    
            }
            CategoryOptions = selectListItems.OrderBy(i=>i.Text).ToList();
        }
    }
}
