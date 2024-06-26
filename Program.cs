using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ProjetoParaEntregar.Context;
using Newtonsoft.Json;
using ProjetoParaEntregar.Entity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrganizadorContext>(options => 

    {
        var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); 
    }
    );

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
    );

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
