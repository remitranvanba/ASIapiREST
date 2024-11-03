using ASIapiREST.Models.DataManager;
using ASIapiREST.Models.DTO;
using ASIapiREST.Models.EntityFramework;
using ASIapiREST.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SerieDBContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("SerieDBContext")));

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDataRepository<UtilisateurDTO>, UtilisateurManager>();
builder.Services.AddScoped<IDataRepository<UtilisateurDetailDTO>, UtilisateurDetailManager>();

var app = builder.Build();

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
