using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Services
{
    public class PcService : IService<PcDto>
    {
        private readonly PcRepository repository;
        public PcService(PcRepository pcRepository)
        {
            repository = pcRepository;
        }
        public async Task<PcDto> AddRow(PcDto entity)
        {
            Pc pc = Pc.FromDto(entity);
            await repository.AddRow(pc);
            return PcDto.FromDao(pc);

        }



        public async Task<PcDto> FindRowByCompositeIds(object[] keyValues)
        {
            Pc pc = await repository.FindRowByCompositeIds(keyValues);
            return PcDto.FromDao(pc);
        }

        public async Task<List<PcDto>> GetAllRows()
        {
            List<Pc> pcs = await repository.GetAllRows();
            if (pcs == null)
            {
                return [];
            }
            List<PcDto> pcDtos = pcs.Select(pc => PcDto.FromDao(pc)).ToList();
            return pcDtos;
        }

        public async Task<PcDto> GetRowById(int id)
        {
            Pc pc = await repository.GetRowById(id);
            if (pc == null)
            {
                throw new KeyNotFoundException($"Pc with ID {id} was not found.");
            }
            return PcDto.FromDao(pc);
        }

        public async Task<PcDto> UpdateRow(int id, PcDto modifiedRow)
        {
            Pc oldPc = await repository.GetRowById(id);
            if (oldPc == null)
            {
                throw new KeyNotFoundException($"Pc with ID {id} was not found.");
            }
            Pc pc = Pc.FromDto(modifiedRow);
            await repository.UpdateRow(pc);
            return modifiedRow;
        }

        public async Task DeleteRow(int id)
        {
            var found = await repository.GetRowById(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Pc with ID {id} was not found.");
            }
            await repository.DeleteRow(id);
        }
    }
}
