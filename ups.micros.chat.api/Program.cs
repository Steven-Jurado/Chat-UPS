using Microsoft.OpenApi.Models;
using ups.micros.chat.api.Extensions;
using ups.micros.chat.infrastructure.ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Micro Autenticacion",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Email = "sjuradom@est.ups.edu.ec",
                Name = "Steven Jurado M."
            }
        });
    swagger.AddSwaggerDocumentation();
});


builder.Services.AddDependencyInjectionInfrastructure();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
