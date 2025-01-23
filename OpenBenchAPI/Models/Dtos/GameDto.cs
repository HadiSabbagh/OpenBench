using OpenBench.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OpenBench.Models
{
    public class GameDto : IDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public double Version { get; set; }

        public GameDto(int id, string name, double version)
        {
            Id = id;
            Name = name;
            Version = version;
        }

        public GameDto()
        {
            
        }
        public static GameDto FromDao(Game game)
        {
            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Version = game.Version
            };
        }
    }

}
