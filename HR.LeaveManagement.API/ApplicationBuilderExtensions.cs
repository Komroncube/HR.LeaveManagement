using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;

namespace HR.LeaveManagement.API;

public static class ApplicationBuilderExtensions
{
    public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(x =>
        {
            x.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature?.Error;

                if (exception is not ValidationException validationException)
                {
                    throw exception;
                }

                var errors = validationException.Errors.Select(err => new
                {
                    PropertyName = err.PropertyName,
                    ErrorMessage = err.ErrorMessage
                });
                var errorText = JsonConvert.SerializeObject(errors);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorText, Encoding.UTF8);
            });
        });

    }

    public static void AddSwaggerDoc(this IServiceCollection services)
    {
        string description = $"JWT Authorization header using the Bearer scheme. {Environment.NewLine} \r\n" +
                            $"Enter 'Bearer' [space] and then your token in the text input below. {Environment.NewLine} \r\n" +
                            $"Example: 'Bearer 1234abcdefg'";
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = description,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new string[] {}
                }
            });

            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "HR LeaveManagement API", 
                Version = "v1" 
            });
        });
    }
}
