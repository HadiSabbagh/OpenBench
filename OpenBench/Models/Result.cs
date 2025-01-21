using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBench.Models
{
    public class Result : IEntity
    {
        [Column("ResultId")]
        public int Id { get; set; }

        [DisplayName("Avg")]
        public double AverageFrameRate { get; set; }

        [DisplayName("Min")]
        public double MinimumFrameRate { get; set; }

        [DisplayName("Max")]
        public double MaximumFrameRate { get; set; }

        [DisplayName("1% low")]
        public double OnePercentLow { get; set; }

        [DisplayName("0.1% low")]
        public double ZeroOnePercentLow { get; set; }
        public int PcId { get; set; }
        public virtual Pc? Pc { get; set; } = null!;

        
        public virtual Game? Game { get; set; } = null!;

        [DisplayName("Game")]
        public string GameName { get; set; } = null!;


        [DisplayName("Version")]
        public double GameVersion { get; set; }


        [EnumDataType(typeof(Resolution))]
        public Resolution Resolution { get; set; }
    }
}
