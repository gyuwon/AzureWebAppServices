using System.Web.Mvc;
using static System.Configuration.ConfigurationManager;

namespace ContactManager.Filters
{
    public class TestGroupActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            string testGroup = AppSettings["TestGroup"] ?? "A";
            filterContext.HttpContext.Response.Headers["TestGroup"] = testGroup;
        }
    }
}
