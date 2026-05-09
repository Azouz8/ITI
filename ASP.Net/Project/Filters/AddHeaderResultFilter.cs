using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.Filters
{
    public class AddHeaderResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // This runs BEFORE the response is sent
            Console.WriteLine("Before Response is sent");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // This runs AFTER the response is sent — nothing needed here
            Console.WriteLine("After Response is sent");

        }
    }
}
