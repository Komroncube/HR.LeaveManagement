using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
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
}
