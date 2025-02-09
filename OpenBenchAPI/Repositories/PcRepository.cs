using OpenBench.Data;
using OpenBench.Models;

namespace OpenBench.Repositories
{
    public class PcRepository : CoreRepository<Pc, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<PcRepository> _logger;
        public PcRepository(BenchWebContext context, ILogger<PcRepository> logger) : base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
        }
    }
}
