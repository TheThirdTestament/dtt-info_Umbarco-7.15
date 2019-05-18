using System.Web.Optimization;
using Umbraco.Core;

namespace dtt_info.App_Code
{
    // reference https://codeshare.co.uk/blog/how-to-use-bundling-to-minify-css-and-javascript-in-mvc-and-umbraco/

    public class BundleConfig : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication,
        ApplicationContext applicationContext)
        { }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication,
           ApplicationContext applicationContext)
        {
            //Scripts
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.validate*"));

            //CSS
            BundleTable.Bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/content/bootstrap.min.css",
                "~/content/css/style.css",
                "~/content/css/RTE.css")
            );
            //BundleTable.EnableOptimizations = true;
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        { }
    }
}
    
        //public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        //{ }

       
        //public static void RegisterBundles(BundleCollection bundles)
        //{
        //    //Scripts
        //    //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //    //    "~/Scripts/jquery-{version}.js"));

        //    //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        //    //    "~/Scripts/jquery.validate*"));

        //    //CSS
        //    BundleTable.Bundles.Add(new StyleBundle("~/bundles/style").Include("~/content/bootstrap.min.css"));
        //    BundleTable.Bundles.Add(new StyleBundle("~/bundles/style").Include("~/content/css/style.css"));
        //    BundleTable.Bundles.Add(new StyleBundle("~/bundles/style").Include("~/content/css/RTE.css"));
        //}
        //public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        //{ }
    