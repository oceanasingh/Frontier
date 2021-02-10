using System.Web;
using System.Web.Optimization;

namespace FrontierTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/cssbundle/mainlayout").Include(
               "~/Content/bootstrap.min.css",
               "~/Content/bootstrap-theam.min.css",
               "~/Content/bootstrap-theam.min.css.map",
                "~/Content/Site.css"
            ));

            bundles.Add(new ScriptBundle("~/jsbundle/mainlayout").Include(
                         "~/Scripts/jquery-{version}.js",
                         "~/ Scripts/jquery.validate.min.js",
                         "~/Scripts/modernizr-*",
                          "~/Scripts/moment.min.js",
                         "~/Scripts/vue.min.js",
                        "~/App/Pages/Index/index.js"
                    ));

        }
    }
}
