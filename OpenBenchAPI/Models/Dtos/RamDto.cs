using OpenBench.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OpenBench.Models
{

    public class RamDto : IDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [EnumDataType(typeof(RamType))]
        public RamType Type { get; set; }

        public string BrandName { get; set; } = null!;

        public int CL { get; set; }
        public int tRCD { get; set; }

        public int tRP { get; set; }

        public int tRas { get; set; }

        public RamDto(int id, string name, RamType type, string brandName, int cL, int tRCD, int tRP, int tRas)
        {
            Id = id;
            Name = name;
            Type = type;
            BrandName = brandName;
            CL = cL;
            this.tRCD = tRCD;
            this.tRP = tRP;
            this.tRas = tRas;
        }

        public RamDto()
        {
            
        }
        public static RamDto FromDao(Ram ram)
        {
            return new RamDto
            {
                Id = ram.Id,
                Name = ram.Name,
                Type = ram.Type,
                BrandName = ram.BrandName,
                CL = ram.CL,
                tRCD = ram.tRCD,
                tRP = ram.tRP,
                tRas = ram.tRas
            };
        }
    }
}
