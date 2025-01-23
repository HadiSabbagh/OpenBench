using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Repositories
{
    public class RamRepository : CoreRepository<Ram, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        public RamRepository(BenchWebContext context) : base(context)
        {

            _dbContext = context;

        }
    }
}
