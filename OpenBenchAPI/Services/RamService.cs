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
            return RamDto.FromDao(ram);

        }


        public async Task<RamDto> FindRowByCompositeIds(object[] keyValues)
        {
            Ram ram = await repository.FindRowByCompositeIds(keyValues);
            return RamDto.FromDao(ram);
        }

        public async Task<List<RamDto>> GetAllRows()
        {
            List<Ram> rams = await repository.GetAllRows();
            if (rams == null)
            {
                return [];
            }
            List<RamDto> ramDtos = rams.Select(ram => RamDto.FromDao(ram)).ToList();
            return ramDtos;
        }

        public async Task<RamDto> GetRowById(int id)
        {
            Ram ram = await repository.GetRowById(id);
            if (ram == null)
            {
                throw new KeyNotFoundException($"Ram with ID {id} was not found.");
            }
            return RamDto.FromDao(ram);
        }

        public async Task<RamDto> UpdateRow(int id, RamDto modifiedRow)
        {
            Ram oldRam = await repository.GetRowById(id);
            if (oldRam == null)
            {
                throw new KeyNotFoundException($"Ram with ID {id} was not found.");
            }
            Ram ram = Ram.FromDto(modifiedRow);
            await repository.UpdateRow(ram);
            return modifiedRow;
        }
        public async Task DeleteRow(int id)
        {
            var foundRam = await repository.GetRowById(id);
            if (foundRam == null)
            {
                throw new KeyNotFoundException($"Ram with ID {id} was not found.");
            }
            await repository.DeleteRow(id);
        }
    }
}
