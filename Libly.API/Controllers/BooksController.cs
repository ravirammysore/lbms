using Libly.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libly.API.Controllers;

[ApiController]  //later swagger will use this
[Route("api/[controller]")]  // /api/books   //we expect this to happen by convention
public class BooksController : ControllerBase
{
    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Dop = new DateTime(1925, 4, 10) },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Dop = new DateTime(1960, 7, 11) },
            new Book { Id = 3, Title = "1984", Dop = new DateTime(1949, 6, 8) }
        };
        return books;
    }

    //GET/5

    //POST

    //PUT

    //DELETE
}