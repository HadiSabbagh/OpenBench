using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Services
{
    public class RamService : IService<RamDto>
    {
        private readonly RamRepository repository;
        public RamService(RamRepository ramRepository)
        {
            repository = ramRepository;
        }
        public async Task<RamDto> AddRow(RamDto entity)
        {
            Ram ram = Ram.FromDto(entity);
            await repository.AddRow(ram);
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<RamDto> FindRowByCompositeIds(object[] keyValues)
        {
            Ram ram = await repository.FindRowByCompositeIds(keyValues);
            return RamDto.FromDao(ram);
        }

        public async Task<List<RamDto>> GetAllRows()
        {
            List<Ram> rams = await repository.GetAllRows();
            List<RamDto> ramDtos = rams.Select(ram => RamDto.FromDao(ram)).ToList();
            return ramDtos;
        }

        public async Task<RamDto> GetRowById(int? id)
        {
            Ram ram = await repository.GetRowById(id);
            return RamDto.FromDao(ram);
        }

        public async Task<RamDto> UpdateRow(int id, RamDto entity)
        {
            Ram ram = Ram.FromDto(entity);
            await repository.UpdateRow(ram);
            return entity;
        }
    }
}
