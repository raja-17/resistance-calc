using System.Web;
using System.Web.Optimization;

namespace ResistanceCalc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/chosen.jquery.min.js",
                        "~/Scripts/index.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/index").Include(
                      "~/Content/chosen.min.css"));
        }
    }
}
