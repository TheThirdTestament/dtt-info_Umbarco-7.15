using System;
using System.Web.Mvc;
using System.Web.Optimization;
using Umbraco.Web;

namespace dtt_info
{
    public class Global : UmbracoApplication
    {

        protected override void OnApplicationStarted(object sender, EventArgs e)        
        {
            //    RouteTable.Routes.MapUmbracoRoute(
            //        "LiteratureRoute", 
            //        "litteratur/{category}", 
            //        new {
            //            controller = "LiteratureOverview",
            //            action = "index",
            //            category = UrlParameter.Optional
            //        }, 
            //        new UmbracoVirtualNodeByIdRouteHandler(1212));

            //    base.OnApplicationStarted(sender, e);


            base.OnApplicationStarted(sender, e);
        }
    }
}