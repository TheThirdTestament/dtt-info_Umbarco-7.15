using dtt_info.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedContentModels;

namespace dtt_info.Controllers
{
    public class LiteratureOverviewController : Umbraco.Web.Mvc.RenderMvcController
    {
        // GET: LitteratureOverview
        public override ActionResult Index(RenderModel model)
        {
            if (RouteData.Values["category"] != null)
            {

                // url segment "category"
                string category = RouteData.Values["category"].ToString();

                LiteratureListViewModel viewModel = new LiteratureListViewModel(model.Content);

                switch (category)
                {
                    case "livets-bog":
                        viewModel.Catagory = "<em>Livets Bog</em>";
                        viewModel.Books = Umbraco.TypedContentAtRoot().First().Descendants().Where(x => x.DocumentTypeAlias == "book").Where(x => x.GetPropertyValue<int>("sortNo") > 0 && x.GetPropertyValue<int>("sortNo") < 10).Select(x => (Book)x).ToList();
                        break;
                    case "det-evige-verdensbillede":
                        viewModel.Catagory = "<em>Det evige verdensbillede</em>";
                        viewModel.Books = Umbraco.TypedContentAtRoot().First().Descendants().Where(x => x.DocumentTypeAlias == "book").Where(x => x.GetPropertyValue<int>("sortNo") > 10 && x.GetPropertyValue<int>("sortNo") < 20).Select(x => (Book)x).ToList();
                        break;
                    case "andre-store-boeger":
                        viewModel.Catagory = "De øvrige store bøger";
                        viewModel.Books = Umbraco.TypedContentAtRoot().First().Descendants().Where(x => x.DocumentTypeAlias == "book").Where(x => x.GetPropertyValue<int>("sortNo") > 20 && x.GetPropertyValue<int>("sortNo") < 50).Select(x => (Book)x).ToList();
                        break;
                    case "smaaboeger":
                        viewModel.Catagory = "Småbøger";
                        viewModel.Books = Umbraco.TypedContentAtRoot().First().Descendants().Where(x => x.DocumentTypeAlias == "book").Where(x => x.GetPropertyValue<int>("sortNo") > 100 && x.GetPropertyValue<int>("sortNo") < 150).Select(x => (Book)x).ToList();
                        break;
                    default:
                        {
                            throw new HttpException(404, "Not Found");
                        }
                }
                return View("LiteratureList", viewModel);
            }
            return View("LiteratureOverview", model);
        }
    }
}