using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dtt_info.Models.DTO
{
    public class EventDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subTitle")]
        public string SubTitle { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDestription { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }
        
        [JsonProperty("location")]
        public LocationDTO Location { get; set; }

        [JsonProperty("registration")]
        public string Registration { get; set; }
        
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        public List<TimeSlothDTO> TimeSloths { get; set; }

        [JsonProperty("images")]
        public List<ImageDTO> Images { get; set; }

        [JsonProperty("videoLinks")]
        public List<LinkDTO> VideoLinks { get; set; }

    }
}