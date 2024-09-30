using Libly.Core.ApiClients;
using Libly.Core.Models;
using Moq;
using FluentAssertions;

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

        [Theory]
        [InlineData("2001-10-01", 2.5, 3.0)]
        [InlineData("1987-05-25", 5.0, 4.0)]
        [InlineData("2024-07-15", 1.0, 3.6)]
        [InlineData("2024-05-21", 4.0, 5.4)]
        public void CalculateRent_Returns_CorrectRent(string dopString, double mockRating, double expectedRent)
        {            
            var bookCUT = new Book()
            {
                Title = It.IsAny<string>(),
                Dop = DateTime.Parse(dopString)
            };
            var mockApiClient = new Mock<IGetRating>();
                        
            mockApiClient
                .Setup(client => client.GetRating(bookCUT.Title))
                .Returns(mockRating);
                                            
            bookCUT.CalculateRent(mockApiClient.Object)
                .Should()
                .BeApproximately(expectedRent, 0.1);
           
        }
    }
}