using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsAdvancedSweetShop.Models.Repos
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
