using Libly.Core.Models;

namespace Libly.Tests
{
    public class BookTests
    {
        [Theory]
        //We can even get this from an external source like an excel sheet
        [InlineData("Test Book","2023-09-01",false)]
        [InlineData("Test Book", "2024-07-01", false)]
        [InlineData("Test Book", "2024-09-15", true)]
        [InlineData("Test Book", "2024-08-30", true)]
        [InlineData("Test Book", "2024-08-30", true)]
        public void IsNew_Works_Well(string title, string dopString, bool expectedResult)
        {
            //Arrange                  
            var book = new Book()
            {
                Title = title,
                Dop = DateTime.Parse(dopString)
            };           

            //Act            
            var result = book.IsNew();

            //Assert            
            Assert.Equal(expectedResult, result);             
        }       
    }
}