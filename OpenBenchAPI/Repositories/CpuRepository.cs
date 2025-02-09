using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Repositories
{
    public class CpuRepository : CoreRepository<Cpu, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<CpuRepository> _logger;
        public CpuRepository(BenchWebContext context, ILogger<CpuRepository> logger) : base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
        }

    }
}
