using HR.LeaveManagement.API;
using HR.LeaveManagement.Application;
using HR.LeaveManagement.Identity;
using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistance;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistanceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy => policy.AllowAnyOrigin()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

builder.Services.AddMvcCore(options =>
{
    options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseFluentValidationExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
