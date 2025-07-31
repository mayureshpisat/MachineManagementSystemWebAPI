using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MachineManagementSystemWebAPI.Services.MachineService>();
var logger_service = builder.Services.AddSingleton<MachineManagementSystemWebAPI.Services.LoggerService>();


// Add CORS - Allow specific origins for better security
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",
                "http://localhost:5500",
                "http://127.0.0.1:5500",
                "http://localhost:8080",
                "file://"  // For direct file opening
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });

    // For development only - allows all origins
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
