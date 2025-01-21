using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class Brand : IEntity
    {
        [Column("BrandId")]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Cpu> Cpus { get; } = new List<Cpu>();
        public ICollection<Gpu> Gpus{ get; } = new List<Gpu>();
        public ICollection<Ram> Rams { get; } = new List<Ram>();


    }
}
