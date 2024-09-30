using Libly.Core.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the BooksContext with DI container
// Lamdas: you are passing a (anonymous) function to another function

builder.Services.AddDbContext<BooksContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
