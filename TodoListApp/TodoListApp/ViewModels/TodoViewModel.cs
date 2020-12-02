using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.ViewModels
{
    public class TodoViewModel
    {
        public TodoViewModel()
        {
            CurrentTask = new Models.Task();
        }

        public List<Models.Task> Tasks { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Category> Categories { get; set; }
        public Filters Filters { get; set; }

        public Dictionary<string, string> DueDateFilters { get; set; }
        public Models.Task CurrentTask { get; set; }

    }
}
