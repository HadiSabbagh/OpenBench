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
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<PcDto> FindRowByCompositeIds(object[] keyValues)
        {
            Pc pc = await repository.FindRowByCompositeIds(keyValues);
            return PcDto.FromDao(pc);
        }

        public async Task<List<PcDto>> GetAllRows()
        {
            List<Pc> pcs = await repository.GetAllRows();
            List<PcDto> pcDtos = pcs.Select(pc => PcDto.FromDao(pc)).ToList();
            return pcDtos;
        }

        public async Task<PcDto> GetRowById(int? id)
        {
            Pc pc = await repository.GetRowById(id);
            return PcDto.FromDao(pc);
        }

        public async Task<PcDto> UpdateRow(int id, PcDto entity)
        {
            Pc pc = Pc.FromDto(entity);
            await repository.UpdateRow(pc);
            return entity;
        }
    }
}
