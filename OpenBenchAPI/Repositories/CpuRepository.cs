using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Repositories
{
    public class CpuRepository : CoreRepository<Cpu, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;

        public CpuRepository(BenchWebContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}
