using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OpenBench.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Brand_phkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Game_phkey", x => x.Id);
                    table.UniqueConstraint("AK_Games_Name_Version", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Cpus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: true),
                    Cores = table.Column<int>(type: "integer", nullable: false),
                    Threads = table.Column<int>(type: "integer", nullable: false),
                    CpuClock = table.Column<double>(type: "double precision", nullable: false),
                    Boost = table.Column<double>(type: "double precision", nullable: false),
                    OcInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cpu_phkey", x => x.Id);
                    table.ForeignKey(
                        name: "lnk_Brand_Cpu",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: true),
                    VRam = table.Column<int>(type: "integer", nullable: false),
                    GpuClock = table.Column<int>(type: "integer", nullable: false),
                    MemoryClock = table.Column<int>(type: "integer", nullable: false),
                    OcInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GPU_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "lnk_Brand_GPU",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: true),
                    CL = table.Column<int>(type: "integer", nullable: false),
                    tRCD = table.Column<int>(type: "integer", nullable: false),
                    tRP = table.Column<int>(type: "integer", nullable: false),
                    tRas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ram_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "lnk_Brand_Ram",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CpuName = table.Column<string>(type: "text", nullable: false),
                    GpuName = table.Column<string>(type: "text", nullable: false),
                    RamName = table.Column<string>(type: "text", nullable: false),
                    ModuleCount = table.Column<int>(type: "integer", nullable: false),
                    SizeGB = table.Column<int>(type: "integer", nullable: false),
                    CpusId = table.Column<int>(type: "integer", nullable: true),
                    GpusId = table.Column<int>(type: "integer", nullable: true),
                    RamsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PC_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "lnk_CPU_PC",
                        column: x => x.CpusId,
                        principalTable: "Cpus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "lnk_GPU_PC",
                        column: x => x.GpusId,
                        principalTable: "Gpus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "lnk_Ram_PC",
                        column: x => x.RamsId,
                        principalTable: "Rams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AverageFrameRate = table.Column<double>(type: "double precision", nullable: false),
                    MinimumFrameRate = table.Column<double>(type: "double precision", nullable: false),
                    MaximumFrameRate = table.Column<double>(type: "double precision", nullable: false),
                    OnePercentLow = table.Column<double>(type: "double precision", nullable: false),
                    ZeroOnePercentLow = table.Column<double>(type: "double precision", nullable: false),
                    PcId = table.Column<int>(type: "integer", nullable: false),
                    GameName = table.Column<string>(type: "text", nullable: false),
                    GameVersion = table.Column<double>(type: "double precision", nullable: false),
                    Resolution = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Results_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Pcs_PcId",
                        column: x => x.PcId,
                        principalTable: "Pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "lnk_Game_Result",
                        columns: x => new { x.GameName, x.GameVersion },
                        principalTable: "Games",
                        principalColumns: new[] { "Name", "Version" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Intel" },
                    { 2, "AMD" },
                    { 3, "ARM" },
                    { 4, "Qualcomm" },
                    { 5, "Apple" },
                    { 6, "NVIDIA" },
                    { 7, "ASUS" },
                    { 8, "EVGA" },
                    { 9, "Corsair" },
                    { 10, "G.Skill" },
                    { 11, "Kingston" },
                    { 12, "Crucial" },
                    { 13, "Samsung" },
                    { 14, "Hynix" },
                    { 15, "Micron" },
                    { 16, "ADATA" },
                    { 17, "Patriot" }
                });

            migrationBuilder.InsertData(
                table: "Cpus",
                columns: new[] { "Id", "Boost", "BrandId", "BrandName", "Cores", "CpuClock", "Name", "OcInfo", "Threads" },
                values: new object[,]
                {
                    { 1, 3.8999999999999999, null, "AMD", 4, 3.6000000000000001, "Ryzen 3 3100", "No OC", 8 },
                    { 2, 4.2999999999999998, null, "AMD", 4, 3.7999999999999998, "Ryzen 3 3300X", "No OC", 8 },
                    { 3, 4.2000000000000002, null, "AMD", 6, 3.6000000000000001, "Ryzen 5 3600", "No OC", 12 },
                    { 4, 4.4000000000000004, null, "AMD", 6, 3.7999999999999998, "Ryzen 5 3600X", "No OC", 12 },
                    { 5, 4.4000000000000004, null, "AMD", 6, 4.0, "Ryzen 5 3600XT", "No OC", 12 },
                    { 6, 4.4000000000000004, null, "AMD", 8, 3.6000000000000001, "Ryzen 7 3700X", "No OC", 16 },
                    { 7, 4.4000000000000004, null, "AMD", 8, 3.7999999999999998, "Ryzen 7 3700XT", "No OC", 16 },
                    { 8, 4.5, null, "AMD", 8, 3.8999999999999999, "Ryzen 7 3800X", "No OC", 16 },
                    { 9, 4.7000000000000002, null, "AMD", 8, 4.0, "Ryzen 7 3800XT", "No OC", 16 },
                    { 10, 4.5999999999999996, null, "AMD", 12, 3.7999999999999998, "Ryzen 9 3900X", "No OC", 24 },
                    { 11, 4.7000000000000002, null, "AMD", 12, 4.0, "Ryzen 9 3900XT", "No OC", 24 },
                    { 12, 4.7000000000000002, null, "AMD", 16, 3.5, "Ryzen 9 3950X", "No OC", 32 },
                    { 13, 4.2000000000000002, null, "AMD", 4, 4.0, "Ryzen 3 5300G", "No OC", 8 },
                    { 14, 4.4000000000000004, null, "AMD", 6, 3.8999999999999999, "Ryzen 5 5600G", "No OC", 12 },
                    { 15, 4.5999999999999996, null, "AMD", 6, 3.7000000000000002, "Ryzen 5 5600X", "No OC", 12 },
                    { 16, 4.5999999999999996, null, "AMD", 6, 4.0, "Ryzen 5 5600XT", "No OC", 12 },
                    { 17, 4.5999999999999996, null, "AMD", 8, 3.7999999999999998, "Ryzen 7 5700X", "No OC", 16 },
                    { 18, 4.5999999999999996, null, "AMD", 8, 3.7999999999999998, "Ryzen 7 5700G", "No OC", 16 },
                    { 19, 4.7000000000000002, null, "AMD", 8, 3.7999999999999998, "Ryzen 7 5800X", "No OC", 16 },
                    { 20, 4.5, null, "AMD", 8, 3.3999999999999999, "Ryzen 7 5800X3D", "No OC", 16 },
                    { 21, 4.7999999999999998, null, "AMD", 12, 3.7000000000000002, "Ryzen 9 5900X", "No OC", 24 },
                    { 22, 4.7000000000000002, null, "AMD", 12, 3.3999999999999999, "Ryzen 9 5900X3D", "No OC", 24 },
                    { 23, 4.9000000000000004, null, "AMD", 16, 3.3999999999999999, "Ryzen 9 5950X", "No OC", 32 },
                    { 24, 4.2000000000000002, null, "Intel", 4, 3.6000000000000001, "Core i3 9100F", "No OC", 4 },
                    { 25, 4.2999999999999998, null, "Intel", 4, 3.7000000000000002, "Core i3 9300", "No OC", 4 },
                    { 26, 4.0999999999999996, null, "Intel", 6, 2.8999999999999999, "Core i5 9400F", "No OC", 6 },
                    { 27, 4.4000000000000004, null, "Intel", 6, 3.0, "Core i5 9500F", "No OC", 6 },
                    { 28, 4.5999999999999996, null, "Intel", 6, 3.7000000000000002, "Core i5 9600K", "No OC", 6 },
                    { 29, 4.9000000000000004, null, "Intel", 8, 3.6000000000000001, "Core i7 9700", "No OC", 8 },
                    { 30, 4.9000000000000004, null, "Intel", 8, 3.6000000000000001, "Core i7 9700K", "No OC", 8 },
                    { 31, 5.0, null, "Intel", 8, 3.6000000000000001, "Core i9 9900K", "No OC", 16 },
                    { 32, 5.0, null, "Intel", 8, 4.0, "Core i9 9900KS", "No OC", 16 },
                    { 33, 4.2999999999999998, null, "Intel", 4, 3.6000000000000001, "Core i3 10100F", "No OC", 8 },
                    { 34, 4.4000000000000004, null, "Intel", 4, 3.7000000000000002, "Core i3 10300", "No OC", 8 },
                    { 35, 4.2999999999999998, null, "Intel", 6, 2.8999999999999999, "Core i5 10400F", "No OC", 12 },
                    { 36, 4.5, null, "Intel", 6, 3.1000000000000001, "Core i5 10500", "No OC", 12 },
                    { 37, 4.7999999999999998, null, "Intel", 6, 4.0999999999999996, "Core i5 10600K", "No OC", 12 },
                    { 38, 4.7999999999999998, null, "Intel", 8, 2.8999999999999999, "Core i7 10700", "No OC", 16 },
                    { 39, 5.0999999999999996, null, "Intel", 8, 3.7999999999999998, "Core i7 10700K", "No OC", 16 },
                    { 40, 5.2999999999999998, null, "Intel", 8, 3.7000000000000002, "Core i9 10900K", "No OC", 16 },
                    { 41, 4.4000000000000004, null, "Intel", 4, 3.6000000000000001, "Core i3 11100F", "No OC", 8 },
                    { 42, 4.4000000000000004, null, "Intel", 4, 3.7999999999999998, "Core i3 11300", "No OC", 8 },
                    { 43, 4.4000000000000004, null, "Intel", 6, 2.6000000000000001, "Core i5 11400F", "No OC", 12 },
                    { 44, 4.5999999999999996, null, "Intel", 6, 2.7000000000000002, "Core i5 11500", "No OC", 12 },
                    { 45, 5.0999999999999996, null, "Intel", 6, 3.8999999999999999, "Core i5 11600K", "No OC", 12 },
                    { 46, 4.9000000000000004, null, "Intel", 8, 2.5, "Core i7 11700", "No OC", 16 },
                    { 47, 5.0, null, "Intel", 8, 3.6000000000000001, "Core i7 11700K", "No OC", 16 },
                    { 48, 5.2999999999999998, null, "Intel", 8, 3.5, "Core i9 11900K", "No OC", 16 },
                    { 49, 4.2999999999999998, null, "Intel", 4, 3.2999999999999998, "Core i3 12100F", "No OC", 8 },
                    { 50, 4.4000000000000004, null, "Intel", 4, 3.3999999999999999, "Core i3 12300", "No OC", 8 },
                    { 51, 4.4000000000000004, null, "Intel", 6, 2.5, "Core i5 12400", "No OC", 12 },
                    { 52, 4.4000000000000004, null, "Intel", 6, 2.5, "Core i5 12400F", "No OC", 12 },
                    { 53, 4.9000000000000004, null, "Intel", 6, 3.7000000000000002, "Core i5 12600K", "No OC", 12 },
                    { 54, 4.9000000000000004, null, "Intel", 12, 2.1000000000000001, "Core i7 12700", "No OC", 20 },
                    { 55, 5.0, null, "Intel", 12, 3.6000000000000001, "Core i7 12700K", "No OC", 20 },
                    { 56, 5.2000000000000002, null, "Intel", 16, 3.2000000000000002, "Core i9 12900K", "No OC", 24 },
                    { 57, 4.5, null, "Intel", 4, 3.3999999999999999, "Core i3 13100F", "No OC", 8 },
                    { 58, 4.5999999999999996, null, "Intel", 4, 3.6000000000000001, "Core i3 13300", "No OC", 8 },
                    { 59, 4.5999999999999996, null, "Intel", 6, 2.5, "Core i5 13400F", "No OC", 12 },
                    { 60, 4.7999999999999998, null, "Intel", 6, 2.7000000000000002, "Core i5 13500", "No OC", 12 },
                    { 61, 5.0999999999999996, null, "Intel", 6, 3.5, "Core i5 13600K", "No OC", 12 },
                    { 62, 5.0, null, "Intel", 12, 2.6000000000000001, "Core i7 13700", "No OC", 20 },
                    { 63, 5.4000000000000004, null, "Intel", 12, 3.3999999999999999, "Core i7 13700K", "No OC", 20 },
                    { 64, 5.5999999999999996, null, "Intel", 24, 3.0, "Core i9 13900K", "No OC", 32 },
                    { 65, 4.5999999999999996, null, "Intel", 4, 3.5, "Core i3 14100F", "No OC", 8 },
                    { 66, 4.7000000000000002, null, "Intel", 4, 3.7000000000000002, "Core i3 14300", "No OC", 8 },
                    { 67, 4.5999999999999996, null, "Intel", 6, 2.6000000000000001, "Core i5 14400F", "No OC", 12 },
                    { 68, 4.7999999999999998, null, "Intel", 6, 2.7000000000000002, "Core i5 14500", "No OC", 12 },
                    { 69, 5.0999999999999996, null, "Intel", 6, 3.6000000000000001, "Core i5 14600K", "No OC", 12 },
                    { 70, 5.0, null, "Intel", 12, 2.5, "Core i7 14700", "No OC", 20 },
                    { 71, 5.4000000000000004, null, "Intel", 12, 3.5, "Core i7 14700K", "No OC", 20 },
                    { 72, 5.5999999999999996, null, "Intel", 24, 3.2000000000000002, "Core i9 14900K", "No OC", 32 }
                });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "BrandId", "BrandName", "GpuClock", "MemoryClock", "Name", "OcInfo", "VRam" },
                values: new object[,]
                {
                    { 1, null, "NVIDIA", 1544, 1750, "NVIDIA GeForce RTX 2080 Ti", "No OC", 11 },
                    { 2, null, "NVIDIA", 1710, 1750, "NVIDIA GeForce RTX 2080", "No OC", 8 },
                    { 3, null, "NVIDIA", 1770, 1400, "NVIDIA GeForce RTX 2070 Super", "No OC", 8 },
                    { 4, null, "NVIDIA", 1680, 1400, "NVIDIA GeForce RTX 2060", "No OC", 6 },
                    { 5, null, "NVIDIA", 1695, 1219, "NVIDIA GeForce RTX 3090", "No OC", 24 },
                    { 6, null, "NVIDIA", 1665, 1188, "NVIDIA GeForce RTX 3080 Ti", "No OC", 12 },
                    { 7, null, "NVIDIA", 1710, 1188, "NVIDIA GeForce RTX 3080", "No OC", 10 },
                    { 8, null, "NVIDIA", 1770, 1188, "NVIDIA GeForce RTX 3070 Ti", "No OC", 8 },
                    { 9, null, "NVIDIA", 1725, 1750, "NVIDIA GeForce RTX 3070", "No OC", 8 },
                    { 10, null, "NVIDIA", 1665, 1400, "NVIDIA GeForce RTX 3060 Ti", "No OC", 8 },
                    { 11, null, "NVIDIA", 1780, 1500, "NVIDIA GeForce RTX 3060", "No OC", 12 },
                    { 12, null, "NVIDIA", 2235, 1312, "NVIDIA GeForce RTX 4090", "No OC", 24 },
                    { 13, null, "NVIDIA", 2505, 1600, "NVIDIA GeForce RTX 4080", "No OC", 16 },
                    { 14, null, "NVIDIA", 2610, 1600, "NVIDIA GeForce RTX 4070 Ti", "No OC", 12 },
                    { 15, null, "NVIDIA", 2470, 1600, "NVIDIA GeForce RTX 4070", "No OC", 12 },
                    { 16, null, "NVIDIA", 2535, 1600, "NVIDIA GeForce RTX 4060 Ti", "No OC", 8 },
                    { 17, null, "NVIDIA", 2370, 1800, "NVIDIA GeForce RTX 4060", "No OC", 8 },
                    { 18, null, "AMD", 1545, 2000, "AMD Radeon RX 590", "No OC", 8 },
                    { 19, null, "AMD", 1257, 2000, "AMD Radeon RX 580", "No OC", 8 },
                    { 20, null, "AMD", 1244, 1750, "AMD Radeon RX 570", "No OC", 4 },
                    { 21, null, "AMD", 1620, 1500, "AMD Radeon RX 5600 XT", "No OC", 6 },
                    { 22, null, "AMD", 1717, 1750, "AMD Radeon RX 5500 XT", "No OC", 8 },
                    { 23, null, "AMD", 2250, 2000, "AMD Radeon RX 6900 XT", "No OC", 16 },
                    { 24, null, "AMD", 2250, 2000, "AMD Radeon RX 6800 XT", "No OC", 16 },
                    { 25, null, "AMD", 2100, 2000, "AMD Radeon RX 6800", "No OC", 16 },
                    { 26, null, "AMD", 2581, 1920, "AMD Radeon RX 6700 XT", "No OC", 12 },
                    { 27, null, "AMD", 2359, 2000, "AMD Radeon RX 6600 XT", "No OC", 8 },
                    { 28, null, "AMD", 2500, 1600, "AMD Radeon RX 7900 XTX", "No OC", 24 },
                    { 29, null, "AMD", 2400, 2000, "AMD Radeon RX 7900 XT", "No OC", 20 },
                    { 30, null, "AMD", 2400, 1800, "AMD Radeon RX 7800 XT", "No OC", 16 },
                    { 31, null, "Intel", 2100, 1400, "Intel Arc A770", "No OC", 16 },
                    { 32, null, "Intel", 2050, 1400, "Intel Arc A750", "No OC", 12 },
                    { 33, null, "Intel", 2000, 1300, "Intel Arc A580", "No OC", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cpus_BrandId",
                table: "Cpus",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "Game_Name_Version_key",
                table: "Games",
                columns: new[] { "Name", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_BrandId",
                table: "Gpus",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_CpusId",
                table: "Pcs",
                column: "CpusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_GpusId",
                table: "Pcs",
                column: "GpusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_RamsId",
                table: "Pcs",
                column: "RamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rams_BrandId",
                table: "Rams",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameName_GameVersion",
                table: "Results",
                columns: new[] { "GameName", "GameVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_Results_PcId",
                table: "Results",
                column: "PcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Cpus");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
