using dtt_info.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web.WebApi;

namespace dtt_info.API
{
    public class EventsController : UmbracoApiController
    {

        public IEnumerable<string> GetAllProducts()
        {
            return new[] { "Table", "Chair", "Desk", "Computer" };
        }

        public string GetAllEvents()
        {
            List<EventDTO> events = new List<EventDTO>();
            var model = Umbraco.TypedContentAtRoot().First().Descendants().Where(x => x.DocumentTypeAlias == "event").Select(x => (Event)x).ToList();

            foreach (var item in model)
            {
                List<ImageDTO> imageList = new List<ImageDTO>();
                List<LinkDTO> videoLinkList = new List<LinkDTO>();
                List<TimeSlothDTO> timeSlothList = new List<TimeSlothDTO>();

                if (item.IntroImages != null && item.IntroImages.Count() > 1) { 
                    foreach (var image in item.IntroImages) {
                        imageList.Add(new ImageDTO { 
                            Id = image.Id,
                            Name= image.GetPropertyValue<string>("name"),
                            Url = image.GetPropertyValue<string>("url"),
                            Height = image.GetPropertyValue<int>("height"),
                            Width = image.GetPropertyValue<int>("width"),
                            Size = image.GetPropertyValue<int>("size"),
                        });
                    }
                }

                if (item.VideoLinks != null && item.VideoLinks.Count() > 1)
                {
                    foreach (var link in item.VideoLinks)
                    {
                        videoLinkList.Add(new LinkDTO
                        {
                            Id = link.Id,
                            Caption = link.Caption,
                            Link= link.Link,
                            NewWindow = link.NewWindow
                        });
                    }
                }

                if (item.Time != null && item.Time.Count() > 1)
                {
                    foreach (var timeSloth in item.Time)
                    {
                        timeSlothList.Add(new TimeSlothDTO
                        {
                            StartTime = timeSloth.GetPropertyValue<DateTime>("startTime"),
                            EndTime = timeSloth.GetPropertyValue<DateTime>("endTime"),
                        });
                    }
                }

                events.Add(new EventDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Title = item.GetPropertyValue("title").ToString(),
                    SubTitle = item.GetPropertyValue("subTitle").ToString(),
                    ShortDestription = item.GetPropertyValue("shortDescription").ToString(),
                    //Details = item.GetPropertyValue("details").ToString(),
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Location = new LocationDTO { 
                        Id = item.Location2.Id, 
                        Title = item.Location2.GetPropertyValue("title").ToString(),
                        Building = item.Location2.GetPropertyValue("building").ToString(),
                        Address = item.Location2.GetPropertyValue("address").ToString(),
                        Zip = item.Location2.GetPropertyValue("zip").ToString(),
                        City = item.Location2.GetPropertyValue("city").ToString(),
                        Country = item.Location2.GetPropertyValue("country").ToString(),
                        Description= item.Location2.GetPropertyValue("description").ToString()
                    },
                    Registration = item.GetPropertyValue("registration").ToString(),
                    TimeSloths = timeSlothList,
                    EventType = item.EventType,
                    Images = imageList,
                    VideoLinks = videoLinkList
                });
            }
            return JsonConvert.SerializeObject(events);
        }
    }
}