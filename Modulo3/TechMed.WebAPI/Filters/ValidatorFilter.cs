using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TechMed.WebAPI.Filters;
public class ValiatorFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                        .SelectMany(e => e.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
            context.Result = new BadRequestObjectResult(errors);
        }
    }

}
