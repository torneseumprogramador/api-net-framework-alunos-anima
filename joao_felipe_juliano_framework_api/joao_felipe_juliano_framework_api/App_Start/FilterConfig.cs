using System.Web;
using System.Web.Mvc;

namespace joao_felipe_juliano_framework_api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
