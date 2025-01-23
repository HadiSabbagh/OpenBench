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

        public static Game FromDto(GameDto dto)
        {
            return new Game
            {
                Id = dto.Id,
                Name = dto.Name,
                Version = dto.Version
            };
        }
    }
}
