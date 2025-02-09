using OpenBench.Data;
using OpenBench.Models;

namespace OpenBench.Repositories
{
    public class GpuRepository : CoreRepository<Gpu, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<GpuRepository> _logger;
        public GpuRepository(BenchWebContext context, ILogger<GpuRepository> logger) : base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
        }
    }
}
