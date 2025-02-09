using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Services
{
    public class GameService : IService<GameDto>
    {
        private readonly GameRepository repository;
        public GameService(GameRepository gameRepository)
        {
            repository = gameRepository;
        }
        public async Task<GameDto> AddRow(GameDto entity)
        {
            Game game = Game.FromDto(entity);
            await repository.AddRow(game);
            return GameDto.FromDao(game);

        }

        public async Task<GameDto> FindRowByCompositeIds(object[] keyValues)
        {
            Game game = await repository.FindRowByCompositeIds(keyValues);
            return GameDto.FromDao(game);
        }

        public async Task<List<GameDto>> GetAllRows()
        {
            List<Game> games = await repository.GetAllRows();
            if (games == null)
            {
                return [];
            }
            List<GameDto> gameDtos = games.Select(game => GameDto.FromDao(game)).ToList();
            return gameDtos;
        }

        public async Task<GameDto> GetRowById(int id)
        {
            Game game = await repository.GetRowById(id);
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with ID {id} was not found.");
            }
            return GameDto.FromDao(game);
        }

        public async Task<GameDto> UpdateRow(int id, GameDto modifiedRow)
        {
            Game oldGame = await repository.GetRowById(id);
            if(oldGame == null)
            {
                throw new KeyNotFoundException($"Game with ID {id} was not found.");
            }
            Game game = Game.FromDto(modifiedRow);
            await repository.UpdateRow(game);
            return modifiedRow;
        }

        public async Task DeleteRow(int id)
        {
            var found = await repository.GetRowById(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Game with ID {id} was not found.");
            }
            await repository.DeleteRow(id);
        }
    }
}
