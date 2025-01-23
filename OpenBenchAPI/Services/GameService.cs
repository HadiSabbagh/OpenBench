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
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<GameDto> FindRowByCompositeIds(object[] keyValues)
        {
            Game game = await repository.FindRowByCompositeIds(keyValues);
            return GameDto.FromDao(game);
        }

        public async Task<List<GameDto>> GetAllRows()
        {
            List<Game> games = await repository.GetAllRows();
            List<GameDto> gameDtos = games.Select(game => GameDto.FromDao(game)).ToList();
            return gameDtos;
        }

        public async Task<GameDto> GetRowById(int? id)
        {
            Game game = await repository.GetRowById(id);
            return GameDto.FromDao(game);
        }

        public async Task<GameDto> UpdateRow(int id, GameDto entity)
        {
            Game game = Game.FromDto(entity);
            await repository.UpdateRow(game);
            return entity;
        }
    }
}
