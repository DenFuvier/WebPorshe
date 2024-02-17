using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebPorshe.Controller;
using WebPorshe.repository;
using WebPorshe.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPorshe, SqlPorsheRepository>();
var app = builder.Build();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
