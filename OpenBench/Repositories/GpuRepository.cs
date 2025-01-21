using OpenBench.Data;
using OpenBench.Models;

namespace OpenBench.Repositories
{
    public class GpuRepository : CoreRepository<Gpu, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;

        public GpuRepository(BenchWebContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
