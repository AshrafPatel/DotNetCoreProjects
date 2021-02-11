using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsAdvancedSweetShop.Models.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CandyDbContext _candyDbContext;
        public CategoryRepository(CandyDbContext candyDbContext)
        {
            _candyDbContext = candyDbContext;
        }
        public IEnumerable<Category> GetAllCategories => _candyDbContext.Categories;
    }
}
