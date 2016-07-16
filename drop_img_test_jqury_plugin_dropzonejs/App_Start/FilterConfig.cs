using System.Web;
using System.Web.Mvc;

namespace drop_img_test_jqury_plugin_dropzonejs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
