using Libly.Core.ApiClients;
using System;
using System.ComponentModel.DataAnnotations;

namespace Libly.Core.Models;

public class Book : BaseModel
{
    public string Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime Dop { get; set; }

    // Navigation property to Category
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    // Parameterless constructor
    public Book() : base()
    {
    }

    // Parameterized constructor
    public Book(int id, string title, DateTime dop, int categoryId) : this()
    {
        Id = id;
        Title = title;
        Dop = dop;
        CategoryId = categoryId;
    }

    public bool IsNew()
    {
       //ternary operator and i have also used a compound expression
        return (DateTime.Now - Dop).TotalDays <= 60 ? true : false;  
    }

    //Book is dependant on a ratingClient
    public double CalculateRent(IGetRating ratingClient )  //2 and 6
    {
        //fetch from an external sytem
        double rating = ratingClient.GetRating(Title);

        double baseRent = 2.0;

        // Newer books cost more
        double ageFactor = (DateTime.Now - Dop).TotalDays < 180 ? 1.5 : 1.0;

        // Normalize rating to a factor between 0 and 1
        double ratingFactor = rating / 5.0;
        
        return baseRent * ageFactor * (1 + ratingFactor); 
    }
}
