using OpenBench.Models.Dtos;
using System.ComponentModel;

namespace OpenBench.Models
{
    public class GameDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public double Version { get; set; }

        public GameDto(Game game)
        {
            this.Name = game.Name;
            this.Version = game.Version;
        }
    }

}
