using System.Web;
using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace rmApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/Theme/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/Theme/css/bootstrap-select.css")
                .Include("~/Content/Theme/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/Theme/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/Theme/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/Theme/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/Theme/css/dataTables.bootstrap.css")
                .Include("~/Content/Theme/css/jquery-ui.css")
                .Include("~/Content/Theme/css/skins/skin-blue.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/Theme/js/plugins/jquery/jquery-3.3.1.min.js")
                .Include("~/Content/Theme/js/jquery-ui.min.js")
                .Include("~/Content/Theme/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/Theme/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/Theme/js/plugins/slimscroll/slimscroll.js")
                .Include("~/Content/Theme/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/Theme/js/plugins/moment/moment.js")
                .Include("~/Content/Theme/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/Theme/js/plugins/icheck/icheck.js")
                .Include("~/Content/Theme/js/plugins/validator.js")
                .Include("~/Content/Theme/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/Theme/js/adminlte.js")
                .Include("~/Content/Theme/js/jquery.dataTables.min.js")
                .Include("~/Content/Theme/js/dataTables.bootstrap.min.js")
                .Include("~/Content/dataTables.buttons.min.js")
                .Include("~/Content/buttons.flash.min.js")
                .Include("~/Content/jszip.min.js")
                .Include("~/Content/pdfmake.min.js")
                .Include("~/Content/vfs_fonts.js")
                .Include("~/Content/buttons.html5.min.js")
                .Include("~/Content/buttons.print.min.js")
                .Include("~/Content/Theme/js/demo.js")
                .Include("~/Content/numeric-comma.js")
                .Include("~/Content/Theme/js/init.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
