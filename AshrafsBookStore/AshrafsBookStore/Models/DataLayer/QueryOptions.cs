using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsBookStore.Models.DataLayer
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public string OrderByDirection { get; set; } = "asc";
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        private string[] includes;
        public string includes
        {
            set.
        }
    }

    public class WhereClauses<T> : List<Expression<Func<T, bool>>>
    {

    }
}
