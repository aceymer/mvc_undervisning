using Jysk2_0.ToastrHelper;
using System.Web;
using System.Web.Mvc;

namespace Jysk2_0
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MessagesActionFilter());
        }
    }
}
