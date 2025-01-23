using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenBench.Models.Dtos
{
    public class GpuDto : IDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public int VRam { get; set; }
        public int GpuClock { get; set; }
        public int MemoryClock { get; set; }
        public string? OcInfo { get; set; }

        public GpuDto(int id, string name, string brandName, int vRam, int gpuClock, int memoryClock, string? ocInfo)
        {
            Id = id;
            Name = name;
            BrandName = brandName;
            VRam = vRam;
            GpuClock = gpuClock;
            MemoryClock = memoryClock;
            OcInfo = ocInfo;
        }

        public GpuDto()
        {

        }
        public static GpuDto FromDao(Gpu gpu)
        {
            return new GpuDto
            {
                Id = gpu.Id,
                Name = gpu.Name,
                BrandName = gpu.BrandName,
                VRam = gpu.VRam,
                GpuClock = gpu.GpuClock,
                MemoryClock = gpu.MemoryClock,
                OcInfo = gpu.OcInfo
            };
        }
    }
}
