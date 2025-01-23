using OpenBench.Models;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;

namespace OpenBench.Services
{
    public class CpuService : IService<CpuDto>
    {
        private readonly CpuRepository repository;
        public CpuService(CpuRepository cpuRepository)
        {
            repository = cpuRepository;
        }

        public async Task<CpuDto> AddRow(CpuDto entity)
        {
            Cpu cpu = Cpu.FromDto(entity);
            await repository.AddRow(cpu);
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<CpuDto> FindRowByCompositeIds(object[] keyValues)
        {
            Cpu cpu = await repository.FindRowByCompositeIds(keyValues);
            return CpuDto.FromDao(cpu);
        }

        public async Task<List<CpuDto>> GetAllRows()
        {
            List<Cpu> cpus = await repository.GetAllRows();
            List<CpuDto> cpuDtos = cpus.Select(cpu => CpuDto.FromDao(cpu)).ToList();
            return cpuDtos;
        }

        public async Task<CpuDto> GetRowById(int? id)
        {
            Cpu cpu = await repository.GetRowById(id);
            return CpuDto.FromDao(cpu);
        }

        public async Task<CpuDto> UpdateRow(int id,CpuDto entity)
        {
            Cpu cpu = Cpu.FromDto(entity);
            await repository.UpdateRow(cpu);
            return entity;
        }
    }
}
