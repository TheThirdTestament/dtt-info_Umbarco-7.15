using dtt_info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedContentModels;

namespace dtt_info.Controllers
{
    public class EventsController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            // The model
            EventListViewModel viewModel = new EventListViewModel(model.Content);
            //viewModel.Events = Umbraco.TypedContentAtRoot().First().Descendants().Where(x => x.DocumentTypeAlias == "event").Select(x => (Event)x).ToList();

            // Submenu
            var eventDropdownDataType = ApplicationContext.Services.DataTypeService.GetDataTypeDefinitionByName("Event - Event type - Dropdown");
            var eventTypes = ApplicationContext.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(eventDropdownDataType.Id).PreValuesAsDictionary.Select(x => x.Value).ToList();
            IEnumerable<IPublishedContent> allEvents = model.Content.Children().Where(x => x.DocumentTypeAlias == "event").Select(x => (Event)x).ToList();

            List<string> subMenuItems = new List<string>();
            foreach (var item in eventTypes)
            {
                if (item.Value != "0" && allEvents.Where(x => x.GetPropertyValue<string>("eventType") == item.Value.ToString()).Count() > 0)
                {
                    subMenuItems.Add(item.Value);
                }
            }
            subMenuItems.Add("Afholdte");

            viewModel.SubMenuItems = subMenuItems;

            var upcommingEvents = model.Content.Children().Where(x => x.GetPropertyValue<DateTime>("endtime") >= DateTime.Now).OrderBy(x => x.GetPropertyValue<DateTime>("StartTime"));
            
            var pastEvents = model.Content.Children().Where(x => x.GetPropertyValue<DateTime>("endtime") < DateTime.Now).OrderBy(x => x.GetPropertyValue<string>("eventType")).ThenByDescending(x => x.GetPropertyValue<DateTime>("StartTime"));
            
            viewModel.Events = upcommingEvents.Where(x => x.GetPropertyValue("eventType").ToString() == "Foredrag").Select(x => (Event)x).ToList();
            viewModel.Catagory = "foredrag";

            if (RouteData.Values["category"] != null)
            {
                // url segment "category"
                string category = RouteData.Values["category"].ToString().ToLower();
                viewModel.Catagory = category;

                if (!subMenuItems.Contains(category, StringComparer.CurrentCultureIgnoreCase))
                {
                    throw new HttpException(404, "Not Found");
                }

                if (category != "afholdte")
                {
                    viewModel.Events = upcommingEvents.Where(x => x.DocumentTypeAlias == "event" && x.GetPropertyValue("eventType").ToString().ToLower() == category).Select(x => (Event)x).ToList();
                }
                else {
                    viewModel.Events = pastEvents.Select(x => (Event)x).ToList();
                }
                return View("Events", viewModel);
            }
            return View("Events", viewModel);
        }
    }
}