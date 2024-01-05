using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace game_center_backend_cs.Presentation.Attributes;

public class SimpleAuthenticationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Items.ContainsKey("UserId")) context.Result = new UnauthorizedResult();

        base.OnActionExecuting(context);
    }
}