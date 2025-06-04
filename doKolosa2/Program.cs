using System.Text.Json.Serialization;
using doKolosa2.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//WAŻNE
string? connectionString = builder.Configuration.GetConnectionString("Default");

//potrzebne zeby sie nie zapetlalo
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});

//WAŻNE
builder.Services.AddDbContext<GakkoDbContext>(opt => 
{
    opt.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();