using OpenBench.Data;
using OpenBench.Models;

namespace OpenBench.Repositories
{
    public class PcRepository : CoreRepository<Pc, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;

        public PcRepository(BenchWebContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
