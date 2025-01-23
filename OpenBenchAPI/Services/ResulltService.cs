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
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<ResultDto> FindRowByCompositeIds(object[] keyValues)
        {
            Result result = await repository.FindRowByCompositeIds(keyValues);
            return ResultDto.FromDao(result);
        }

        public async Task<List<ResultDto>> GetAllRows()
        {
            List<Result> results = await repository.GetAllRows();
            List<ResultDto> resultDtos = results.Select(result => ResultDto.FromDao(result)).ToList();
            return resultDtos;
        }

        public async Task<ResultDto> GetRowById(int? id)
        {
            Result result = await repository.GetRowById(id);
            return ResultDto.FromDao(result);
        }

        public async Task<ResultDto> UpdateRow(int id, ResultDto entity)
        {
            Result result = Result.FromDto(entity);
            await repository.UpdateRow(result);
            return entity;
        }
    }
}
