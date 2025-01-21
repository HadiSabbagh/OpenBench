using OpenBench.Models.Dtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{

    public class RamDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [EnumDataType(typeof(RamType))]
        public RamType Type { get; set; }

        public string BrandName { get; set; } = null!;

        public int CL { get; set; }
        public int tRCD { get; set; }

        public int tRP { get; set; }

        public int tRas { get; set; }
        public RamDto(Ram ram)
        {
            this.Name = ram.Name;
            this.Type = ram.Type;
            this.BrandName = ram.BrandName;
            this.CL = ram.CL;
            this.tRCD = ram.tRCD;
            this.tRP = ram.tRP;
            this.tRas = ram.tRas;

        }
    }
}
