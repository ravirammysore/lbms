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
        private readonly BooksContext _context;

        [BindProperty] //Devs had to manually process the body
        public BookViewModel BookVM { get; set; }

        //We have a constructor which will be supplied a BooksContext object
        //in run time by the asp.net core framework (using the DI container)
        public CreateModel(BooksContext context)
        {
            _context = context;
        }

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

          
            //Now, we are using the injected context
            _context.Books.Add(Book);    // we have only added the new book to in-memory DbSet
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private void PopulateDropdown()
        {            
            var selectListItems = new List<SelectListItem>();

            foreach(var category in _context.Categories)
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
