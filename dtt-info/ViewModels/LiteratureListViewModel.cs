using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedContentModels;

namespace dtt_info.ViewModels
{
    public class LiteratureListViewModel: RenderModel
    {
        public LiteratureListViewModel(IPublishedContent content) : base(content)
        {
            IEnumerable<Book> Books = new List<Book>();
        }
        public string Catagory { get; set; }
        public IEnumerable<Umbraco.Web.PublishedContentModels.Book> Books { get; set; }
    }
}