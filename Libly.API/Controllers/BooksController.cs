using Libly.Core.Data;
using Libly.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libly.API.Controllers;

[ApiController]  //later swagger will use this
[Route("api/[controller]")]  // /api/books   //we expect this to happen by convention
public class BooksController : ControllerBase
{
    private readonly BooksContext _context;
    public BooksController(BooksContext context)
    {
            _context = context; 
    }
    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
       //the convertion of a c# collection of objects to JSON response is acvtly handled
        //by a built-in serializer in .NET
        return _context.Books
            //.Include(b=>b.Category)
            .ToList();  
    }

    //GET/5

    //POST

    //PUT

    //DELETE
}