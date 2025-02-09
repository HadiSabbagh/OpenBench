using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;
namespace OpenBench.Repositories
{
    public class BrandRepository : CoreRepository<Brand, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<BrandRepository> _logger;
        public BrandRepository(BenchWebContext context, ILogger<BrandRepository> logger) : base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
        }
    }
}
