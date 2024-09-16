using Libly.Data;
using Libly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty] //Devs had to manually process the body
        public Book Book { get; set; }      
       
        public void OnGet()
        {

        }
        //This is also invoked auto when the server receives a POST request from the client
        public ActionResult OnPost()
        {
            //Validate the book 
            if(!ModelState.IsValid)
            {
                return Page();
            }
            BooksData.Create(Book); //upto the data-service 

            return RedirectToPage("./Index");
        }
    }
}
