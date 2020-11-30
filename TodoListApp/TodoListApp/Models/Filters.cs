using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Models
{
    public class Filters
    {
        public string FilterString { get; set; }
        public string CategoryId { get; set; }
        public string DueDate { get; set; }
        public string StatusId { get; set; }
        public Filters(string filterString)
        {
            FilterString = filterString ?? "all-all-all";
            string[] filters = FilterString.Split("-");
            CategoryId = filters[0];
            DueDate = filters[1];
            StatusId = filters[2];
        }

        public bool HasCategoryFilter => CategoryId.ToLower() != "all";
        public bool HasDueDateFilter => CategoryId.ToLower() != "all";
        public bool HasStatusFilter => CategoryId.ToLower() != "all";

        public static Dictionary<string, string> DueDateFilterValues =>
            new Dictionary<string, string>
            {
                {"future", "Future" },
                {"past", "Past" },
                {"today", "Today" }
            };

        public bool IsPast => DueDate.ToLower() == "past";
        public bool IsFuture => DueDate.ToLower() == "future";
        public bool IsToday => DueDate.ToLower() == "today";
    }
}
