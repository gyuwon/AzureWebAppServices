using System.Web.Mvc;
using ContactManager.Filters;

namespace ContactManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ApplicationInsightsHandleErrorAttribute());
            filters.Add(new TestGroupActionFilterAttribute());
        }
    }
}
