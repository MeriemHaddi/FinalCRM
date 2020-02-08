using System.Web;
using System.Web.Optimization;

namespace pi.webb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.unobtrustive.js",
                         "~/Scripts/jquery.validate.unobtrustive.min.js",
                         "~/Scripts/toastr.js",
                         "~/Scripts/c3.min.js",
                         "~/Scripts/d3.min.js",
                         "~/Scripts/jquery-1.10.2.min.js"
                         )) ;

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css",
                      "~/Content/c3.css"
                      ));

            //admin

            bundles.Add(new ScriptBundle("~/bundles/crm/js").Include(
                        "~/wp-content/themes/djezzy/assets/js/app.minfb74.js?v=16"));
            bundles.Add(new StyleBundle("~/Content/crm/css").Include(
                     "~/Content/bootstrap.css",
                     "~/wp-content/themes/djezzy/assets/css/core.mince31.css?v=19"));


        }
    }
}
