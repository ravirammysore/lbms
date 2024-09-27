namespace Libly.Core.ApiClients;

//An interface is a pure abstract class
//We will only have method signatures

//We are seperating What to do and How to do
public interface IGetRating
{
    //Method signature
    double GetRating(string bookTitle);  
}
