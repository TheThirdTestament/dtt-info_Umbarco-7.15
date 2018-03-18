using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace dtt_info.Controllers
{
    public class LiteratureOverviewController : Umbraco.Web.Mvc.RenderMvcController
    {
        // GET: LitteratureOverview
        public override ActionResult Index(RenderModel model)
        {
            if (RouteData.Values["category"] != null) { 
                var category = RouteData.Values["category"].ToString();
                
                IPublishedContent root = Umbraco.TypedContentAtRoot().First();
                IEnumerable<IPublishedContent> books = root.FirstChild("literatureOverview").Children().Where(x => x.IsVisible()).ToList();

                return View("LiteratureList", model);
            }

            return View("LiteratureOverview", model);
        }
    }
}

