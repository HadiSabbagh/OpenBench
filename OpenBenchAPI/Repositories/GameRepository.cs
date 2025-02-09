using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Repositories
{
    public class GameRepository : CoreRepository<Game, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<GameRepository> _logger;
        public GameRepository(BenchWebContext context, ILogger<GameRepository> logger) : base(context, logger)
        {

            _dbContext = context;
            _logger = logger;
        }
    }
}
