using System.ComponentModel.DataAnnotations.Schema;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;

namespace OpenBench.Models
{
    public class BrandDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public BrandDto(Brand brand)
        {
            this.Name = brand.Name;
        }
    }

}
