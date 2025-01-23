using OpenBench.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OpenBench.Models
{
    public class CpuDto : IDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public int Cores { get; set; }

        public int Threads { get; set; }

        public double CpuClock { get; set; }

        public double BoostClock { get; set; }

        public string? OcInfo { get; set; }

        public CpuDto(int id, string name, string brandName, int cores, int threads, double cpuClock, double boostClock, string? ocInfo)
        {
            Id = id;
            Name = name;
            BrandName = brandName;
            Cores = cores;
            Threads = threads;
            CpuClock = cpuClock;
            BoostClock = boostClock;
            OcInfo = ocInfo;
        }

        public CpuDto()
        {
            
        }
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
