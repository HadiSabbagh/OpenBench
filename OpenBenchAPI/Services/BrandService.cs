using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Services
{
    public class BrandService : IService<BrandDto>
    {

        private readonly BrandRepository repository;
        public BrandService(BrandRepository brandRepository)
        {
            repository = brandRepository;
        }
        public async Task<BrandDto> AddRow(BrandDto entity)
        {
            Brand brand = Brand.FromDto(entity);
            await repository.AddRow(brand);
            return entity;
        }

        public async Task DeleteRow(int id)
        {
            await repository.DeleteRow(id);
        }

        public async Task<BrandDto> FindRowByCompositeIds(object[] keyValues)
        {
            Brand brand = await repository.FindRowByCompositeIds(keyValues);
            return BrandDto.FromDao(brand);
        }

        public async Task<List<BrandDto>> GetAllRows()
        {
            List<Brand> brands = await repository.GetAllRows();
            List<BrandDto> brandDtos = brands.Select(brand => BrandDto.FromDao(brand)).ToList();
            return brandDtos;
        }

        public async Task<BrandDto> GetRowById(int? id)
        {
            Brand brand = await repository.GetRowById(id);
            return BrandDto.FromDao(brand);
        }

        public async Task<BrandDto> UpdateRow(int id, BrandDto modifiedRow)
        {
            Brand oldRow = await repository.GetRowById(id);
            if (oldRow != null)
            {
                oldRow.Name = modifiedRow.Name;
                await repository.UpdateRow(oldRow);
            }
            else
            {
                throw new InvalidOperationException("Row not found");
            }
            return modifiedRow;
        }
    }
}
