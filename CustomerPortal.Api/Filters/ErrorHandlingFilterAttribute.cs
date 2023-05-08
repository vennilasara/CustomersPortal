using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomersPortal.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            context.Result = new ObjectResult(new { error = "An error occurred while processing your request"})
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
