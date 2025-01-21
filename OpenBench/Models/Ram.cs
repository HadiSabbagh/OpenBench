using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{

    public class Ram : IEntity
    {
        [Column("RamId")]
        public int Id { get; set; }
        [DisplayName("Name")]

        public string Name { get; set; } = null!;

        [EnumDataType(typeof(RamType))]
        public RamType Type { get; set; }

        [DisplayName("Brand")]

        public string BrandName { get; set; } = null!;
        public virtual Brand? Brand { get; set; } = null!;

        public ICollection<Pc>? Pcs { get; set; } = null!;

        public int CL { get; set; }
        public int tRCD { get; set; }

        public int tRP { get; set; }

        public int tRas { get; set; }
    }
}
