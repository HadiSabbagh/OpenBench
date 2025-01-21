using OpenBench.Models.Dtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class CpuDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        [DisplayName("Brand")]

        public string BrandName { get; set; } = null!;

        public int Cores { get; set; }

        public int Threads { get; set; }

        public double CpuClock { get; set; }

        public double BoostClock { get; set; }

        public string? OcInfo { get; set; }

        /* public CpuDto(Cpu cpu)
         {
             this.Id = cpu.Id;
             this.Name = cpu.Name;
             this.BrandName = cpu.BrandName;
             this.Cores = cpu.Cores;
             this.Threads = cpu.Threads;
             this.CpuClock = cpu.CpuClock;
             this.BoostClock = cpu.Boost;
             this.OcInfo = cpu.OcInfo;
         }*/
        public static CpuDto FromDao(Cpu cpu)
        {
            return new CpuDto
            {
                Id = cpu.Id,
                Name = cpu.Name,
                BrandName = cpu.BrandName,
                Cores = cpu.Cores,
                Threads = cpu.Threads,
                CpuClock = cpu.CpuClock,
                BoostClock = cpu.Boost,
                OcInfo = cpu.OcInfo
            };
        }
    }
}
