using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Synergetic.Exercise.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.*",
                "~/Scripts/Pages/syn.delete-confirmation.js"));

            bundles.Add(new ScriptBundle("~/bundles/companies").Include(
                "~/Scripts/Pages/Company/syn.overview.js"));
        }
    }
}