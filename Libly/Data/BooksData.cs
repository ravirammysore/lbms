using Libly.Models;

namespace Libly.Data
{
    public static class BooksData
    {
        //class-level member
        private static List<Book> books = new List<Book>
        {
            new Book(1, "The Great Gatsby", "Fiction", new DateTime(1925, 4, 10)),
            new Book(2, "To Kill a Mockingbird", "Fiction", new DateTime(1960, 7, 11)),
            new Book(3, "1984", "Dystopian", new DateTime(1949, 6, 8)),
            new Book(4, "Pride and Prejudice", "Romance", new DateTime(1813, 1, 28))
        };

        //Create
        public static void Create(Book book)
        {
            //what do we do with the ID?
            int newId = 0;

            if (books.Count > 0)
            {
                //LINQ , a power
                var maxID = books.Max(b => b.Id);
                newId = maxID + 1;
            }
            else
            {
                newId = 1;
            }

            book.Id = newId;
            books.Add(book);
        }
        
        //Retrive
        public static List<Book> GetAll()
        {
            return books;
        }

        public static Book Get(int id)
        {
            //return books[id];   
            return books.FirstOrDefault(book => book.Id == id);
        }

        public static void Update(Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                //We have auto-mappers
                //nuget package manager (star ratings, no of download)
                book.Title = updatedBook.Title;
                book.Category = updatedBook.Category;
                book.Dop = updatedBook.Dop;
                book.ModifiedOn = DateTime.Now;
            }
        }

        // Delete a book by ID
        public static void Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);                
            }
        }
    }
}
