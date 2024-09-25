using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages
{
    public class ErrorModel : PageModel
    {
        public int ErrorCode { get; set; }
        public void OnGet()
        {
            //We did log, get a number
            ErrorCode = 1534;
        }
    }
}
