using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;
namespace OpenBench.Repositories
{
    public class BrandRepository : CoreRepository<Brand, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;

        public BrandRepository(BenchWebContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
