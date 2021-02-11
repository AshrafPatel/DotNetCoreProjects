using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsAdvancedSweetShop.Models.Repos
{
    public class CandyRepository : ICandyRepository
    {
        private readonly CandyDbContext _candyDbContext;
        public CandyRepository(CandyDbContext candyDbContext)
        {
            _candyDbContext = candyDbContext;
        }

        public IEnumerable<Candy> GetAllCandy
        {
            get 
            {
                return _candyDbContext.Candies.Include(c => c.Category);
            }
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return _candyDbContext.Candies.Include(c => c.Category).Where(p => p.IsOnSale);
            }
        }

        public Candy GetCandyById(int candyId)
        {
            return _candyDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
