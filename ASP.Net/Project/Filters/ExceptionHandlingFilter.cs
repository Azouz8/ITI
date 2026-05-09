using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentApi.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception caught in filter => {context.Exception.Message}");

            context.Result = new ObjectResult(new
            {
                statusCode = 500,
                message = "Error caught by exception filter",
                detail = context.Exception.Message
            })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}