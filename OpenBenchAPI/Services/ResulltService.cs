using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Services
{
    public class ResultService : IService<ResultDto>
    {
        private readonly ResultRepository repository;
        public ResultService(ResultRepository resultRepository)
        {
            repository = resultRepository;
        }
        public async Task<ResultDto> AddRow(ResultDto entity)
        {
            Result result = Result.FromDto(entity);
            await repository.AddRow(result);
            return ResultDto.FromDao(result);
        }

       

        public async Task<ResultDto> FindRowByCompositeIds(object[] keyValues)
        {
            Result result = await repository.FindRowByCompositeIds(keyValues);
            return ResultDto.FromDao(result);
        }

        public async Task<List<ResultDto>> GetAllRows()
        {
            List<Result> results = await repository.GetAllRows();
            if (results == null)
            {
                return [];
            }
            List<ResultDto> resultDtos = results.Select(result => ResultDto.FromDao(result)).ToList();
            return resultDtos;
        }

        public async Task<ResultDto> GetRowById(int id)
        {
            Result result = await repository.GetRowById(id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Result with ID {id} was not found.");
            }
            return ResultDto.FromDao(result);
        }

        public async Task<ResultDto> UpdateRow(int id, ResultDto modifiedRow)
        {
            Result oldResult = await repository.GetRowById(id);
            if (oldResult == null)
            {
                throw new KeyNotFoundException($"Result with ID {id} was not found.");
            }
            Result result = Result.FromDto(modifiedRow);
            await repository.UpdateRow(result);
            return modifiedRow;
        }

        public async Task DeleteRow(int id)
        {
            var foundResult = await repository.GetRowById(id);
            if (foundResult == null)
            {
                throw new KeyNotFoundException($"Result with ID {id} was not found.");
            }
            await repository.DeleteRow(id);
        }
    }
}
