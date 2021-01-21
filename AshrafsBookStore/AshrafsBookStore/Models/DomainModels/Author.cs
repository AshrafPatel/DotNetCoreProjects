using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsBookStore.Models.DomainModels
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Please enter First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
