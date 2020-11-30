using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Please enter a Due Date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please select a Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please select a Status")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool Overdue => DateTime.Today > DueDate && StatusId == "open";
    }
}
