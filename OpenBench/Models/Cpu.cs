using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class Cpu : IEntity
    {
        [Column("CpuId")]
        public int Id { get; set; }
        [DisplayName("Name")]

        public string Name { get; set; } = null!;
        [DisplayName("Brand")]

        public string BrandName { get; set; } = null!;
        public virtual Brand? Brand { get; set; } 

        public ICollection<Pc>? Pcs { get; set; }

        public int Cores { get; set; }

        [DisplayName("Threads/Efficiency Cores")]
        public int Threads { get; set; }

        [DisplayName("Cpu Clock(GHz)")]
        public double CpuClock { get; set; }

        [DisplayName("Boost(GHz)")]
        public double Boost { get; set; }
        
        public string? OcInfo { get; set; }

        public static Cpu FromDto(CpuDto cpuDto)
        {
            return new Cpu
            {
                Id = cpuDto.Id,
                Name = cpuDto.Name,
                BrandName = cpuDto.BrandName,
                Cores = cpuDto.Cores,
                Threads = cpuDto.Threads,
                CpuClock = cpuDto.CpuClock,
                Boost = cpuDto.BoostClock,
                OcInfo = cpuDto.OcInfo

            };
        }
    }
}
