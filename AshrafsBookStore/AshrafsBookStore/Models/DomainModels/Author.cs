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
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter Last Name")]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
}
