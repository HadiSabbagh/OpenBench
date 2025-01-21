using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class Pc : IEntity
    {
        [Column("PcId")]
        public int Id { get; set; }

        [DisplayName("Cpu")]
        public string CpuName { get; set; } = null!;

        [DisplayName("Gpu")]
        public string GpuName { get; set; } = null!;

        [DisplayName("Ram")]
        public string RamName { get; set; } = null!;

        [DisplayName("Module Count")]
        public int ModuleCount { get; set; }

        [DisplayName("Module Size(GB)")]
        public int SizeGB { get; set; }

        public Cpu? Cpus { get; set; }
        public Gpu? Gpus { get; set; }
        public Ram? Rams { get; set; }

        public ICollection<Result> Results { get; } = new List<Result>();

    }
}
