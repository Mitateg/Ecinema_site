using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Ecinema_site.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            // CSS Bundles
            var cssBundle = new StyleBundle("~/Content/css");
            cssBundle.Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-grid.min.css",
                "~/Content/bootstrap-reboot.min.css",
                "~/Content/Site.css");
            bundles.Add(cssBundle);

            // JavaScript Bundles
            var jsBundle = new ScriptBundle("~/Scripts/js");
            jsBundle.Include(
                "~/Scripts/jquery-3.6.0.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/Site.js");
            bundles.Add(jsBundle);
        }
    }
}