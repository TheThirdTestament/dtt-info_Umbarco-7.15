using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace dtt_info
{
    public class Global : UmbracoApplication
    {
        //protected override void OnApplicationStarted(object sender, EventArgs e)        
        //{
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
        //}
    }
}