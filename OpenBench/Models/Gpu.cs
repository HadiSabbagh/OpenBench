using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class Gpu : IEntity
    {
        [Column("GpuId")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; } = null!;
        [DisplayName("Brand")]

        public string BrandName { get; set; } = null!;

        public virtual Brand? Brand { get; set; } = null!;

        public ICollection<Pc>? Pcs { get; set; } = null!;

        [DisplayName("VRam (GB)")]
        public int VRam { get; set; }

        [DisplayName("Gpu Clock(MHz)")]
        public int GpuClock { get; set; }

        [DisplayName("Memory Clock(MHz)")]
        public int MemoryClock { get; set; }

        public string? OcInfo { get; set; }
    }
}
