using System.ComponentModel;

namespace OpenBench.Models
{
    public class Game : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; } = null!;
        public double Version { get; set; }


        public ICollection<Result> Result { get; } = new List<Result>();
    }
}
