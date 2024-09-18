using Libly.Data;
using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty] //Devs had to manually process the body
        public Book Book { get; set; }

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
            BooksData.Create(Book); //upto the data-service 

            return RedirectToPage("./Index");
        }

        private void PopulateDropdown()
        {
            //Object Initialization Syntax
            CategoryOptions = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "1",
                    Text = "Fiction"
                },

                new SelectListItem
                {
                    Value = "2",
                    Text = "Science Fiction"
                }
            };
        }
    }
}
