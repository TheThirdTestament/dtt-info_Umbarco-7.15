using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace dtt_info.App_Code
{
    public class CustomApplicationEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // Custom route to MyProductController which will use a node with a specific ID as the
            // IPublishedContent for the current rendering page
            RouteTable.Routes.MapUmbracoRoute(
                "ProductCustomRoute",
                "Litteratur/{category}",
                new
                {
                    controller = "LiteratureOverview",
                    action = "index",
                    category = UrlParameter.Optional
                },
                new UmbracoVirtualNodeByIdRouteHandler(1212));


            RouteTable.Routes.MapUmbracoRoute(
                "EventCustomRoute",
                "Arrangementer/{category}",
                new
                {
                    controller = "Arrangementer",
                    action = "index",
                    category = UrlParameter.Optional
                },
                new UmbracoVirtualNodeByIdRouteHandler(2665));
        }
    }


    // new UmbracoVirtualNodeByIdRouteHandler(New FindJobPageRouteHandler));
    //public class FindJobPageRouteHandler : UmbracoVirtualNodeRouteHandler
    //{
    //    protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
    //    {
    //        // change this to whatever you need, but make sure it is fast!
    //        var jobspage = umbracoContext.ContentCache.GetAtRoot().First().FirstChild<LiteratureOverview>();
    //        return jobspage;
    //    }
    //}

}