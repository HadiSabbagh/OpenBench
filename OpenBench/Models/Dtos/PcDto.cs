using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;

namespace OpenBench.Models
{
    public class PcDto : IDto
    {
        public int Id { get; set; }

        public string CpuName { get; set; } = null!;


        public string GpuName { get; set; } = null!;


        public string RamName { get; set; } = null!;

        public int ModuleCount { get; set; }


        public int SizeGB { get; set; }

        public PcDto(Pc pc)
        {
            this.CpuName = pc.CpuName;
            this.GpuName = pc.GpuName;
            this.RamName = pc.RamName;
            this.ModuleCount = pc.ModuleCount;
            this.SizeGB = pc.SizeGB;
        }

    }
}
