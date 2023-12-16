namespace HR.LeaveManagement.Application.Validations
{
    public sealed class ValidationExceptionHandlingMiddleware
    {

        //yaxshiroq davr uchun olib qo'yildi
        //private readonly RequestDelegate _next;

        //public ValidationExceptionHandlingMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        //    _logger = logger;
        //}

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    try
        //    {
        //        await _next(context);
        //    }
        //    catch (ValidationException exception)
        //    {
        //        var problemDetails = new ProblemDetails
        //        {
        //            Status = StatusCodes.Status400BadRequest,
        //            Type = "ValidationFailure",
        //            Title = "Validation error",
        //            Detail = "One or more validation errors has occurred"
        //        };

        //        if (exception.Errors is not null)
        //        {
        //            problemDetails.Extensions["errors"] = exception.Errors;
        //        }

        //        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        //        await context.Response.WriteAsJsonAsync(problemDetails);
        //    }
    }
}

