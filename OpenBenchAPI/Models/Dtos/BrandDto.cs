using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenBench.Models
{
    public class BrandDto : IDto
    {
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public BrandDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public BrandDto()
        {

        }
        public static BrandDto FromDao(Brand brand)
        {
            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }
    }

}
