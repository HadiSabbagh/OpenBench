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
            return CpuDto.FromDao(cpu);
        }

       

        public async Task<CpuDto> FindRowByCompositeIds(object[] keyValues)
        {
            Cpu cpu = await repository.FindRowByCompositeIds(keyValues);
            return CpuDto.FromDao(cpu);
        }

        public async Task<List<CpuDto>> GetAllRows()
        {
            List<Cpu> cpus = await repository.GetAllRows();
            if (cpus == null)
            {
                return [];
            }
            List<CpuDto> cpuDtos = cpus.Select(cpu => CpuDto.FromDao(cpu)).ToList();
            return cpuDtos;
        }

        public async Task<CpuDto> GetRowById(int id)
        {
            Cpu cpu = await repository.GetRowById(id);
            if (cpu == null)
            {
                throw new KeyNotFoundException($"Cpu with ID {id} was not found.");
            }
            return CpuDto.FromDao(cpu);
        }

        public async Task<CpuDto> UpdateRow(int id,CpuDto modifiedRow)
        {
            Cpu oldCpu = await repository.GetRowById(id);
            if (oldCpu == null)
            {
                throw new KeyNotFoundException($"Cpu with ID {id} was not found.");
            }
            Cpu cpu = Cpu.FromDto(modifiedRow);
            await repository.UpdateRow(cpu);
            return modifiedRow;
        }

        public async Task DeleteRow(int id)
        {
            var found = await repository.GetRowById(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Cpu with ID {id} was not found.");
            }
            await repository.DeleteRow(id);
        }
    }
}
