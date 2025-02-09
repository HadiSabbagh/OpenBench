using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Repositories
{
    public class RamRepository : CoreRepository<Ram, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<RamRepository> _logger;
        public RamRepository(BenchWebContext context, ILogger<RamRepository> logger) : base(context, logger)
        {

            _dbContext = context;
            _logger = logger;
        }
    }
}
