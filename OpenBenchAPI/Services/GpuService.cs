using OpenBench.Models;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;
namespace OpenBench.Services
{
    public class GpuService : IService<GpuDto>
    {
        private readonly GpuRepository repository;
        public GpuService(GpuRepository gpuRepository)
        {
            repository = gpuRepository;
        }
        public async Task<GpuDto> AddRow(GpuDto entity)
        {
            Gpu gpu = Gpu.FromDto(entity);
            await repository.AddRow(gpu);
             return GpuDto.FromDao(gpu);

        }



        public async Task<GpuDto> FindRowByCompositeIds(object[] keyValues)
        {
            Gpu gpu = await repository.FindRowByCompositeIds(keyValues);
            return GpuDto.FromDao(gpu);
        }

        public async Task<List<GpuDto>> GetAllRows()
        {
            List<Gpu> gpus = await repository.GetAllRows();
            if (gpus == null)
            {
                return [];
            }
            List<GpuDto> gpuDtos = gpus.Select(gpu => GpuDto.FromDao(gpu)).ToList();
            return gpuDtos;
        }

        public async Task<GpuDto> GetRowById(int id)
        {
            Gpu gpu = await repository.GetRowById(id);
            if (gpu == null)
            {
                throw new KeyNotFoundException($"Gpu with ID {id} was not found.");
            }
            return GpuDto.FromDao(gpu);
        }

        public async Task<GpuDto> UpdateRow(int id, GpuDto modifiedRow)
        {
            Gpu oldGpu = await repository.GetRowById(id);
            if (oldGpu == null)
            {
                throw new KeyNotFoundException($"Gpu with ID {id} was not found.");
            }
            Gpu gpu = Gpu.FromDto(modifiedRow);
            await repository.UpdateRow(gpu);
            return modifiedRow;
        }

        public async Task DeleteRow(int id)
        {
            var found = await repository.GetRowById(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Gpu with ID {id} was not found.");
            }
            await repository.DeleteRow(id);
        }
    }
}
