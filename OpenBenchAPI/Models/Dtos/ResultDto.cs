using OpenBench.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OpenBench.Models
{
    public class ResultDto : IDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public double AverageFrameRate { get; set; }


        public double MinimumFrameRate { get; set; }


        public double MaximumFrameRate { get; set; }


        public double OnePercentLow { get; set; }


        public double ZeroOnePercentLow { get; set; }
        public int PcId { get; set; }



        public string GameName { get; set; } = null!;


        [DisplayName("Version")]
        public double GameVersion { get; set; }


        [EnumDataType(typeof(Resolution))]
        public Resolution Resolution { get; set; }

        public ResultDto(int id, double averageFrameRate, double minimumFrameRate,
            double maximumFrameRate, double onePercentLow, double zeroOnePercentLow,
            int pcId, string gameName, double gameVersion, Resolution resolution)
        {
            Id = id;
            AverageFrameRate = averageFrameRate;
            MinimumFrameRate = minimumFrameRate;
            MaximumFrameRate = maximumFrameRate;
            OnePercentLow = onePercentLow;
            ZeroOnePercentLow = zeroOnePercentLow;
            PcId = pcId;
            GameName = gameName;
            GameVersion = gameVersion;
            Resolution = resolution;
        }

        public ResultDto()
        {

        }

        public static ResultDto FromDao(Result result)
        {
            return new ResultDto
            {
                Id = result.Id,
                AverageFrameRate = result.AverageFrameRate,
                MinimumFrameRate = result.MinimumFrameRate,
                MaximumFrameRate = result.MaximumFrameRate,
                OnePercentLow = result.OnePercentLow,
                ZeroOnePercentLow = result.ZeroOnePercentLow,
                PcId = result.PcId,
                GameName = result.GameName,
                GameVersion = result.GameVersion,
                Resolution = result.Resolution
            };
        }
    }
}
