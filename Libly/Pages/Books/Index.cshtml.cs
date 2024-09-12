using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //external package (lib)

namespace Libly.Pages.Books // namespace (folder)
{
    public class IndexModel : PageModel //class  //PascalCase
    {
        public string[] bookNames; //camel
        public void OnGet() //function
        {
            //eventually i will pull this from database
            bookNames = [
              "The Great Gatsby",
                "To Kill a Mockingbird",
                "The God Father",
                "Pride and Prejudice"
          ];
        }      
    }
}
