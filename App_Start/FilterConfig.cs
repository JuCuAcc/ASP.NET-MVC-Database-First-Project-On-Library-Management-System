using System.Web;
using System.Web.Mvc;

namespace Library_Mvc_Jashim
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
