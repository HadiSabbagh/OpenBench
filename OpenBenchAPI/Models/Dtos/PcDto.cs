using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenBench.Models
{
    public class PcDto : IDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string CpuName { get; set; } = null!;


        public string GpuName { get; set; } = null!;


        public string RamName { get; set; } = null!;

        public int ModuleCount { get; set; }


        public int SizeGB { get; set; }

        public PcDto(int id, string cpuName, string gpuName, string ramName, int moduleCount, int sizeGB)
        {
            Id = id;
            CpuName = cpuName;
            GpuName = gpuName;
            RamName = ramName;
            ModuleCount = moduleCount;
            SizeGB = sizeGB;
        }
        public PcDto()
        {
            
        }

        public static PcDto FromDao(Pc pc)
        {
            return new PcDto
            {
                Id = pc.Id,
                CpuName = pc.CpuName,
                GpuName = pc.GpuName,
                RamName = pc.RamName,
                ModuleCount = pc.ModuleCount,
                SizeGB = pc.SizeGB
            };
        }

    }
}
