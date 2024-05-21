using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Data;
using PatientInfoPortal.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PatientInfoPortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"))
);

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<INcdRepository, NcdRepository>();
builder.Services.AddScoped<IDiseaseRepository, DiseaseRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
