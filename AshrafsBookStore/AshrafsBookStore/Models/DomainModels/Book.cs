using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsBookStore.Models.DomainModels
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter a Title")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Range(0.0, 1000.0, ErrorMessage = "Price must be more then 0 and less than a thousand")]
        public double Price { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
