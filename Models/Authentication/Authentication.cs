/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cs_Plantlover.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"area", "Identity" },
                    {"Controller", "Account" },
                    {"Action","Login" },
                    {"Action","Register" }
                });
            }
            else
            {
                // Kiểm tra vai trò của người dùng
                var userRole = context.HttpContext.Session.GetString("UserRole");
                if (context.Controller.GetType().Namespace.Contains("Admin") && (userRole == null || userRole != "Admin"))
                {
                    // Nếu người dùng cố gắng truy cập vào Controller Admin mà không phải là admin, chuyển hướng đến trang người dùng
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"Controller", "Access" },
                        {"Action","Home" }
                    });
                }
            }
        }
    }
}
*/