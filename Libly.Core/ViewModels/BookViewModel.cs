using System.ComponentModel.DataAnnotations;

namespace Libly.Core.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Book titles are mandatory for adding a new book!"), Length(1, 30)]        
        public string Title { get; set; }
        public DateTime Dop { get; set; }
        public int CategoryId { get; set; }
    }
}
