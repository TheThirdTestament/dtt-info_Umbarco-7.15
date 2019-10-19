using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedContentModels;

namespace dtt_info.ViewModels
{
    public class EventListViewModel : RenderModel
        {
            public EventListViewModel(IPublishedContent content) : base(content)
            {
                IEnumerable<Event> Events = new List<Event>();
            }
            public string Catagory { get; set; }
            public IEnumerable<Umbraco.Web.PublishedContentModels.Event> Events { get; set; }
        
    }
}