using OpenBench.Models.Dtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class ResultDto : IDto
    {
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

        public ResultDto(Result result)
        {
            this.AverageFrameRate = result.AverageFrameRate;
            this.MinimumFrameRate = result.MinimumFrameRate;
            this.MaximumFrameRate = result.MaximumFrameRate;
            this.OnePercentLow = result.OnePercentLow;
            this.ZeroOnePercentLow = result.ZeroOnePercentLow;
            this.PcId = result.PcId;
            this.GameName = result.GameName;
            this.GameVersion = result.GameVersion;
            this.Resolution = result.Resolution;


        }
    }
}
