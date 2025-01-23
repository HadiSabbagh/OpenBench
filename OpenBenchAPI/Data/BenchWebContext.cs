using OpenBench.Models;
using Microsoft.EntityFrameworkCore;

namespace OpenBench.Data
{
    public class BenchWebContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public BenchWebContext(IConfiguration config)
        {
            _configuration = config;
        }
        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Cpu> Cpus { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Gpu> Gpus { get; set; }

        public virtual DbSet<Pc> Pcs { get; set; }

        public virtual DbSet<Ram> Rams { get; set; }

        public virtual DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Brand_phkey");

                //entity.HasKey(e => e.Id).HasName("Brand_phkey");
                entity.HasData(
                   new Brand { Id = 1, Name = "Intel" },
                   new Brand { Id = 2, Name = "AMD" },
                   new Brand { Id = 3, Name = "ARM" },
                   new Brand { Id = 4, Name = "Qualcomm" },
                   new Brand { Id = 5, Name = "Apple" },
                   new Brand { Id = 6, Name = "NVIDIA" },
                   new Brand { Id = 7, Name = "ASUS" },
                   new Brand { Id = 8, Name = "EVGA" },
                   new Brand { Id = 9, Name = "Corsair" },
                   new Brand { Id = 10, Name = "G.Skill" },
                   new Brand { Id = 11, Name = "Kingston" },
                   new Brand { Id = 12, Name = "Crucial" },
                   new Brand { Id = 13, Name = "Samsung" },
                   new Brand { Id = 14, Name = "Hynix" },
                   new Brand { Id = 15, Name = "Micron" },
                   new Brand { Id = 16, Name = "ADATA" },
                   new Brand { Id = 17, Name = "Patriot" });
            });


            modelBuilder.Entity<Cpu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Cpu_phkey");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Brand).WithMany(p => p.Cpus).HasConstraintName("lnk_Brand_Cpu").HasPrincipalKey("Id");

                entity.HasData(
                    new Cpu { Id = 1, Name = "Ryzen 3 3100", BrandName = "AMD", Cores = 4, Threads = 8, CpuClock = 3.6, Boost = 3.9, OcInfo = "No OC" },
                    new Cpu { Id = 2, Name = "Ryzen 3 3300X", BrandName = "AMD", Cores = 4, Threads = 8, CpuClock = 3.8, Boost = 4.3, OcInfo = "No OC" },
                    new Cpu { Id = 3, Name = "Ryzen 5 3600", BrandName = "AMD", Cores = 6, Threads = 12, CpuClock = 3.6, Boost = 4.2, OcInfo = "No OC" },
                    new Cpu { Id = 4, Name = "Ryzen 5 3600X", BrandName = "AMD", Cores = 6, Threads = 12, CpuClock = 3.8, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 5, Name = "Ryzen 5 3600XT", BrandName = "AMD", Cores = 6, Threads = 12, CpuClock = 4.0, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 6, Name = "Ryzen 7 3700X", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.6, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 7, Name = "Ryzen 7 3700XT", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.8, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 8, Name = "Ryzen 7 3800X", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.9, Boost = 4.5, OcInfo = "No OC" },
                    new Cpu { Id = 9, Name = "Ryzen 7 3800XT", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 4.0, Boost = 4.7, OcInfo = "No OC" },
                    new Cpu { Id = 10, Name = "Ryzen 9 3900X", BrandName = "AMD", Cores = 12, Threads = 24, CpuClock = 3.8, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 11, Name = "Ryzen 9 3900XT", BrandName = "AMD", Cores = 12, Threads = 24, CpuClock = 4.0, Boost = 4.7, OcInfo = "No OC" },
                    new Cpu { Id = 12, Name = "Ryzen 9 3950X", BrandName = "AMD", Cores = 16, Threads = 32, CpuClock = 3.5, Boost = 4.7, OcInfo = "No OC" },
                    new Cpu { Id = 13, Name = "Ryzen 3 5300G", BrandName = "AMD", Cores = 4, Threads = 8, CpuClock = 4.0, Boost = 4.2, OcInfo = "No OC" },
                    new Cpu { Id = 14, Name = "Ryzen 5 5600G", BrandName = "AMD", Cores = 6, Threads = 12, CpuClock = 3.9, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 15, Name = "Ryzen 5 5600X", BrandName = "AMD", Cores = 6, Threads = 12, CpuClock = 3.7, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 16, Name = "Ryzen 5 5600XT", BrandName = "AMD", Cores = 6, Threads = 12, CpuClock = 4.0, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 17, Name = "Ryzen 7 5700X", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.8, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 18, Name = "Ryzen 7 5700G", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.8, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 19, Name = "Ryzen 7 5800X", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.8, Boost = 4.7, OcInfo = "No OC" },
                    new Cpu { Id = 20, Name = "Ryzen 7 5800X3D", BrandName = "AMD", Cores = 8, Threads = 16, CpuClock = 3.4, Boost = 4.5, OcInfo = "No OC" },
                    new Cpu { Id = 21, Name = "Ryzen 9 5900X", BrandName = "AMD", Cores = 12, Threads = 24, CpuClock = 3.7, Boost = 4.8, OcInfo = "No OC" },
                    new Cpu { Id = 22, Name = "Ryzen 9 5900X3D", BrandName = "AMD", Cores = 12, Threads = 24, CpuClock = 3.4, Boost = 4.7, OcInfo = "No OC" },
                    new Cpu { Id = 23, Name = "Ryzen 9 5950X", BrandName = "AMD", Cores = 16, Threads = 32, CpuClock = 3.4, Boost = 4.9, OcInfo = "No OC" },
                    new Cpu { Id = 24, Name = "Core i3 9100F", BrandName = "Intel", Cores = 4, Threads = 4, CpuClock = 3.6, Boost = 4.2, OcInfo = "No OC" },
                    new Cpu { Id = 25, Name = "Core i3 9300", BrandName = "Intel", Cores = 4, Threads = 4, CpuClock = 3.7, Boost = 4.3, OcInfo = "No OC" },
                    new Cpu { Id = 26, Name = "Core i5 9400F", BrandName = "Intel", Cores = 6, Threads = 6, CpuClock = 2.9, Boost = 4.1, OcInfo = "No OC" },
                    new Cpu { Id = 27, Name = "Core i5 9500F", BrandName = "Intel", Cores = 6, Threads = 6, CpuClock = 3.0, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 28, Name = "Core i5 9600K", BrandName = "Intel", Cores = 6, Threads = 6, CpuClock = 3.7, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 29, Name = "Core i7 9700", BrandName = "Intel", Cores = 8, Threads = 8, CpuClock = 3.6, Boost = 4.9, OcInfo = "No OC" },
                    new Cpu { Id = 30, Name = "Core i7 9700K", BrandName = "Intel", Cores = 8, Threads = 8, CpuClock = 3.6, Boost = 4.9, OcInfo = "No OC" },
                    new Cpu { Id = 31, Name = "Core i9 9900K", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 3.6, Boost = 5.0, OcInfo = "No OC" },
                    new Cpu { Id = 32, Name = "Core i9 9900KS", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 4.0, Boost = 5.0, OcInfo = "No OC" },
                    new Cpu { Id = 33, Name = "Core i3 10100F", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.6, Boost = 4.3, OcInfo = "No OC" },
                    new Cpu { Id = 34, Name = "Core i3 10300", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.7, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 35, Name = "Core i5 10400F", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.9, Boost = 4.3, OcInfo = "No OC" },
                    new Cpu { Id = 36, Name = "Core i5 10500", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 3.1, Boost = 4.5, OcInfo = "No OC" },
                    new Cpu { Id = 37, Name = "Core i5 10600K", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 4.1, Boost = 4.8, OcInfo = "No OC" },
                    new Cpu { Id = 38, Name = "Core i7 10700", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 2.9, Boost = 4.8, OcInfo = "No OC" },
                    new Cpu { Id = 39, Name = "Core i7 10700K", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 3.8, Boost = 5.1, OcInfo = "No OC" },
                    new Cpu { Id = 40, Name = "Core i9 10900K", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 3.7, Boost = 5.3, OcInfo = "No OC" },
                    new Cpu { Id = 41, Name = "Core i3 11100F", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.6, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 42, Name = "Core i3 11300", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.8, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 43, Name = "Core i5 11400F", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.6, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 44, Name = "Core i5 11500", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.7, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 45, Name = "Core i5 11600K", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 3.9, Boost = 5.1, OcInfo = "No OC" },
                    new Cpu { Id = 46, Name = "Core i7 11700", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 2.5, Boost = 4.9, OcInfo = "No OC" },
                    new Cpu { Id = 47, Name = "Core i7 11700K", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 3.6, Boost = 5.0, OcInfo = "No OC" },
                    new Cpu { Id = 48, Name = "Core i9 11900K", BrandName = "Intel", Cores = 8, Threads = 16, CpuClock = 3.5, Boost = 5.3, OcInfo = "No OC" },
                    new Cpu { Id = 49, Name = "Core i3 12100F", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.3, Boost = 4.3, OcInfo = "No OC" },
                    new Cpu { Id = 50, Name = "Core i3 12300", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.4, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 51, Name = "Core i5 12400", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.5, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 52, Name = "Core i5 12400F", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.5, Boost = 4.4, OcInfo = "No OC" },
                    new Cpu { Id = 53, Name = "Core i5 12600K", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 3.7, Boost = 4.9, OcInfo = "No OC" },
                    new Cpu { Id = 54, Name = "Core i7 12700", BrandName = "Intel", Cores = 12, Threads = 20, CpuClock = 2.1, Boost = 4.9, OcInfo = "No OC" },
                    new Cpu { Id = 55, Name = "Core i7 12700K", BrandName = "Intel", Cores = 12, Threads = 20, CpuClock = 3.6, Boost = 5.0, OcInfo = "No OC" },
                    new Cpu { Id = 56, Name = "Core i9 12900K", BrandName = "Intel", Cores = 16, Threads = 24, CpuClock = 3.2, Boost = 5.2, OcInfo = "No OC" },
                    new Cpu { Id = 57, Name = "Core i3 13100F", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.4, Boost = 4.5, OcInfo = "No OC" },
                    new Cpu { Id = 58, Name = "Core i3 13300", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.6, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 59, Name = "Core i5 13400F", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.5, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 60, Name = "Core i5 13500", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.7, Boost = 4.8, OcInfo = "No OC" },
                    new Cpu { Id = 61, Name = "Core i5 13600K", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 3.5, Boost = 5.1, OcInfo = "No OC" },
                    new Cpu { Id = 62, Name = "Core i7 13700", BrandName = "Intel", Cores = 12, Threads = 20, CpuClock = 2.6, Boost = 5.0, OcInfo = "No OC" },
                    new Cpu { Id = 63, Name = "Core i7 13700K", BrandName = "Intel", Cores = 12, Threads = 20, CpuClock = 3.4, Boost = 5.4, OcInfo = "No OC" },
                    new Cpu { Id = 64, Name = "Core i9 13900K", BrandName = "Intel", Cores = 24, Threads = 32, CpuClock = 3.0, Boost = 5.6, OcInfo = "No OC" },
                    new Cpu { Id = 65, Name = "Core i3 14100F", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.5, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 66, Name = "Core i3 14300", BrandName = "Intel", Cores = 4, Threads = 8, CpuClock = 3.7, Boost = 4.7, OcInfo = "No OC" },
                    new Cpu { Id = 67, Name = "Core i5 14400F", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.6, Boost = 4.6, OcInfo = "No OC" },
                    new Cpu { Id = 68, Name = "Core i5 14500", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 2.7, Boost = 4.8, OcInfo = "No OC" },
                    new Cpu { Id = 69, Name = "Core i5 14600K", BrandName = "Intel", Cores = 6, Threads = 12, CpuClock = 3.6, Boost = 5.1, OcInfo = "No OC" },
                    new Cpu { Id = 70, Name = "Core i7 14700", BrandName = "Intel", Cores = 12, Threads = 20, CpuClock = 2.5, Boost = 5.0, OcInfo = "No OC" },
                    new Cpu { Id = 71, Name = "Core i7 14700K", BrandName = "Intel", Cores = 12, Threads = 20, CpuClock = 3.5, Boost = 5.4, OcInfo = "No OC" },
                    new Cpu { Id = 72, Name = "Core i9 14900K", BrandName = "Intel", Cores = 24, Threads = 32, CpuClock = 3.2, Boost = 5.6, OcInfo = "No OC" }
    );
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Game_phkey");
                //entity.HasKey(e => e.Id).HasName("Game_phkey");
                entity.HasIndex(e => new { e.Name, e.Version }).IsUnique().HasDatabaseName("Game_Name_Version_key");


            });

            modelBuilder.Entity<Gpu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("GPU_pkey");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Brand).WithMany(p => p.Gpus).HasConstraintName("lnk_Brand_GPU").HasPrincipalKey("Id");

                modelBuilder.Entity<Gpu>().HasData(
            // NVIDIA 20 Series
            new Gpu { Id = 1, Name = "NVIDIA GeForce RTX 2080 Ti", BrandName = "NVIDIA", VRam = 11, GpuClock = 1544, MemoryClock = 1750, OcInfo = "No OC" },
            new Gpu { Id = 2, Name = "NVIDIA GeForce RTX 2080", BrandName = "NVIDIA", VRam = 8, GpuClock = 1710, MemoryClock = 1750, OcInfo = "No OC" },
            new Gpu { Id = 3, Name = "NVIDIA GeForce RTX 2070 Super", BrandName = "NVIDIA", VRam = 8, GpuClock = 1770, MemoryClock = 1400, OcInfo = "No OC" },
            new Gpu { Id = 4, Name = "NVIDIA GeForce RTX 2060", BrandName = "NVIDIA", VRam = 6, GpuClock = 1680, MemoryClock = 1400, OcInfo = "No OC" },

            // NVIDIA 30 Series
            new Gpu { Id = 5, Name = "NVIDIA GeForce RTX 3090", BrandName = "NVIDIA", VRam = 24, GpuClock = 1695, MemoryClock = 1219, OcInfo = "No OC" },
            new Gpu { Id = 6, Name = "NVIDIA GeForce RTX 3080 Ti", BrandName = "NVIDIA", VRam = 12, GpuClock = 1665, MemoryClock = 1188, OcInfo = "No OC" },
            new Gpu { Id = 7, Name = "NVIDIA GeForce RTX 3080", BrandName = "NVIDIA", VRam = 10, GpuClock = 1710, MemoryClock = 1188, OcInfo = "No OC" },
            new Gpu { Id = 8, Name = "NVIDIA GeForce RTX 3070 Ti", BrandName = "NVIDIA", VRam = 8, GpuClock = 1770, MemoryClock = 1188, OcInfo = "No OC" },
            new Gpu { Id = 9, Name = "NVIDIA GeForce RTX 3070", BrandName = "NVIDIA", VRam = 8, GpuClock = 1725, MemoryClock = 1750, OcInfo = "No OC" },
            new Gpu { Id = 10, Name = "NVIDIA GeForce RTX 3060 Ti", BrandName = "NVIDIA", VRam = 8, GpuClock = 1665, MemoryClock = 1400, OcInfo = "No OC" },
            new Gpu { Id = 11, Name = "NVIDIA GeForce RTX 3060", BrandName = "NVIDIA", VRam = 12, GpuClock = 1780, MemoryClock = 1500, OcInfo = "No OC" },

            // NVIDIA 40 Series
            new Gpu { Id = 12, Name = "NVIDIA GeForce RTX 4090", BrandName = "NVIDIA", VRam = 24, GpuClock = 2235, MemoryClock = 1312, OcInfo = "No OC" },
            new Gpu { Id = 13, Name = "NVIDIA GeForce RTX 4080", BrandName = "NVIDIA", VRam = 16, GpuClock = 2505, MemoryClock = 1600, OcInfo = "No OC" },
            new Gpu { Id = 14, Name = "NVIDIA GeForce RTX 4070 Ti", BrandName = "NVIDIA", VRam = 12, GpuClock = 2610, MemoryClock = 1600, OcInfo = "No OC" },
            new Gpu { Id = 15, Name = "NVIDIA GeForce RTX 4070", BrandName = "NVIDIA", VRam = 12, GpuClock = 2470, MemoryClock = 1600, OcInfo = "No OC" },
            new Gpu { Id = 16, Name = "NVIDIA GeForce RTX 4060 Ti", BrandName = "NVIDIA", VRam = 8, GpuClock = 2535, MemoryClock = 1600, OcInfo = "No OC" },
            new Gpu { Id = 17, Name = "NVIDIA GeForce RTX 4060", BrandName = "NVIDIA", VRam = 8, GpuClock = 2370, MemoryClock = 1800, OcInfo = "No OC" },

            // AMD Radeon 5000 Series
            new Gpu { Id = 18, Name = "AMD Radeon RX 590", BrandName = "AMD", VRam = 8, GpuClock = 1545, MemoryClock = 2000, OcInfo = "No OC" },
            new Gpu { Id = 19, Name = "AMD Radeon RX 580", BrandName = "AMD", VRam = 8, GpuClock = 1257, MemoryClock = 2000, OcInfo = "No OC" },
            new Gpu { Id = 20, Name = "AMD Radeon RX 570", BrandName = "AMD", VRam = 4, GpuClock = 1244, MemoryClock = 1750, OcInfo = "No OC" },
            new Gpu { Id = 21, Name = "AMD Radeon RX 5600 XT", BrandName = "AMD", VRam = 6, GpuClock = 1620, MemoryClock = 1500, OcInfo = "No OC" },
            new Gpu { Id = 22, Name = "AMD Radeon RX 5500 XT", BrandName = "AMD", VRam = 8, GpuClock = 1717, MemoryClock = 1750, OcInfo = "No OC" },

            // AMD Radeon 6000 Series
            new Gpu { Id = 23, Name = "AMD Radeon RX 6900 XT", BrandName = "AMD", VRam = 16, GpuClock = 2250, MemoryClock = 2000, OcInfo = "No OC" },
            new Gpu { Id = 24, Name = "AMD Radeon RX 6800 XT", BrandName = "AMD", VRam = 16, GpuClock = 2250, MemoryClock = 2000, OcInfo = "No OC" },
            new Gpu { Id = 25, Name = "AMD Radeon RX 6800", BrandName = "AMD", VRam = 16, GpuClock = 2100, MemoryClock = 2000, OcInfo = "No OC" },
            new Gpu { Id = 26, Name = "AMD Radeon RX 6700 XT", BrandName = "AMD", VRam = 12, GpuClock = 2581, MemoryClock = 1920, OcInfo = "No OC" },
            new Gpu { Id = 27, Name = "AMD Radeon RX 6600 XT", BrandName = "AMD", VRam = 8, GpuClock = 2359, MemoryClock = 2000, OcInfo = "No OC" },

            // AMD Radeon 7000 Series
            new Gpu { Id = 28, Name = "AMD Radeon RX 7900 XTX", BrandName = "AMD", VRam = 24, GpuClock = 2500, MemoryClock = 1600, OcInfo = "No OC" },
            new Gpu { Id = 29, Name = "AMD Radeon RX 7900 XT", BrandName = "AMD", VRam = 20, GpuClock = 2400, MemoryClock = 2000, OcInfo = "No OC" },
            new Gpu { Id = 30, Name = "AMD Radeon RX 7800 XT", BrandName = "AMD", VRam = 16, GpuClock = 2400, MemoryClock = 1800, OcInfo = "No OC" },

            // Intel GPUs
            new Gpu { Id = 31, Name = "Intel Arc A770", BrandName = "Intel", VRam = 16, GpuClock = 2100, MemoryClock = 1400, OcInfo = "No OC" },
            new Gpu { Id = 32, Name = "Intel Arc A750", BrandName = "Intel", VRam = 12, GpuClock = 2050, MemoryClock = 1400, OcInfo = "No OC" },
            new Gpu { Id = 33, Name = "Intel Arc A580", BrandName = "Intel", VRam = 8, GpuClock = 2000, MemoryClock = 1300, OcInfo = "No OC" }
        );
            });
            modelBuilder.Entity<Pc>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PC_pkey");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Cpus).WithMany(p => p.Pcs).HasConstraintName("lnk_CPU_PC").HasPrincipalKey("Id");

                entity.HasOne(d => d.Gpus).WithMany(p => p.Pcs).HasConstraintName("lnk_GPU_PC").HasPrincipalKey("Id");

                entity.HasOne(d => d.Rams).WithMany(p => p.Pcs).HasConstraintName("lnk_Ram_PC").HasPrincipalKey("Id");



            });
            modelBuilder.Entity<Ram>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Ram_pkey");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).HasConversion(
                    v => v.ToString(),
                    v => (RamType)Enum.Parse(typeof(RamType), v));

                entity.HasOne(d => d.Brand).WithMany(p => p.Rams).HasConstraintName("lnk_Brand_Ram").HasPrincipalKey("Id");
            });
            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Results_pkey");

                entity.HasOne(d => d.Game).WithMany(p => p.Result).HasConstraintName("lnk_Game_Result").HasPrincipalKey(e => new { e.Name, e.Version });

                entity.Property(e => e.Resolution).HasConversion(
                    v => v.ToString(),
                    v => (Resolution)Enum.Parse(typeof(Resolution), v));

            });


        }



    }
}
