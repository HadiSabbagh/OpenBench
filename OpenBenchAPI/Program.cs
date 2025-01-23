using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using OpenBench.Data;
using OpenBench.Repositories;
using OpenBench.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.EnableAnnotations();
});



builder.Services.AddDbContext<BenchWebContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));




//Register repositories
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<PcRepository>();
builder.Services.AddScoped<ResultRepository>();
builder.Services.AddScoped<CpuRepository>();
builder.Services.AddScoped<GpuRepository>();
builder.Services.AddScoped<RamRepository>();
builder.Services.AddScoped<GameRepository>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<CpuService>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<GpuService>();
builder.Services.AddScoped<PcService>();
builder.Services.AddScoped<RamService>();
builder.Services.AddScoped<ResultService>();



var app = builder.Build();
app.UseRewriter(new RewriteOptions().AddRedirect("^$", "/swagger"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
