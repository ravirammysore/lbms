using Libly.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//adds Razor Pages services to the DI container.
builder.Services.AddRazorPages();

// Register the BooksContext with DI container
// Lamdas: you are passing a (anonymous) function to another function

builder.Services.AddDbContext<BooksContext>(
    options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB"))
    );


var app = builder.Build();

//config that u do here (settings) are called Middleware
//app.MapGet("/", () => "Welcome to Libly!");

/*
 * UseRouting means that we won't be hardcoding every route, rather
 * the framework should figure it out dynamically based on conventions
 */

//object.function()
app.UseRouting();
/*
 *  MapRazorPages() tells the app to look for Razor Pages in the Pages folder 
 *  and handle requests accordingly. Other option is MVC style controllers
 */
app.MapRazorPages();

app.Run();
