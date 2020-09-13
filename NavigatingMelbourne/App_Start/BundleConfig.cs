using System.Web;
using System.Web.Optimization;

namespace NavigatingMelbourne
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/js/jquery.min.js",
                      "~/js/move-top.js",
                      "~/js/easing.js",
                      "~/js/jquery.waypoints.min.js",
                      "~/js/jquery.countup.js",
                      "~/js/jquery.typer.js",
                      "~/js/main.js",
                      "~/js/bootstrap.min.js",
                      "~/js/jquery.dataTables.min.js",
                      "~/js/dataTables.bootstrap4.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                          "~/js/jquery.min.js"
                         ));
    

                bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/fontawesome-all.css",
                      "~/css/style.css",
                      "~/css/dataTables.bootstrap4.min.css"
             ));
        }
    }
}
