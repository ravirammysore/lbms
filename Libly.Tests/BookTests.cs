using Libly.Core.ApiClients;
using Libly.Core.Models;
using Moq;

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

        [Fact]
        public void CalculateRent_Returns_CorrectRent()
        {
            //Arrange
            var book = new Book()
            {
                Title = "Some title",
                Dop = DateTime.Parse("2001-10-01")
            };
            var mockApiClient = new Mock<IGetRating>();
            
            //We are pre-programing this mock object to behave the way we want
            mockApiClient.Setup(client => client.GetRating(book.Title)).Returns(2.5);
            
            //Act
            // If i get a rating of 2.5 of 5 stars
            var actualrent = book.CalculateRent(mockApiClient.Object);

            //Assert
            // 2.0 * 1.0 * (1 + (2.5/5.0)) = 3.0
            Assert.Equal(3.0, actualrent);
        }
    }
}