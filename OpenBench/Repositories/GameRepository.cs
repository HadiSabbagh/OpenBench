using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Repositories
{
    public class GameRepository : CoreRepository<Game, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        public GameRepository(BenchWebContext context) : base(context)
        {

            _dbContext = context;

        }
    }
}
