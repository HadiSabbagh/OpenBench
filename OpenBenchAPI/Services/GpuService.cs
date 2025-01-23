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
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<GpuDto> FindRowByCompositeIds(object[] keyValues)
        {
            Gpu gpu = await repository.FindRowByCompositeIds(keyValues);
            return GpuDto.FromDao(gpu);
        }

        public async Task<List<GpuDto>> GetAllRows()
        {
            List<Gpu> gpus = await repository.GetAllRows();
            List<GpuDto> gpuDtos = gpus.Select(gpu => GpuDto.FromDao(gpu)).ToList();
            return gpuDtos;
        }

        public async Task<GpuDto> GetRowById(int? id)
        {
            Gpu gpu = await repository.GetRowById(id);
            return GpuDto.FromDao(gpu);
        }

        public async Task<GpuDto> UpdateRow(int id, GpuDto entity)
        {
            Gpu gpu = Gpu.FromDto(entity);
            await repository.UpdateRow(gpu);
            return entity;
        }
    }
}
