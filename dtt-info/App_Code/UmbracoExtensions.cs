using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace dtt_info.App_Code
{
    public static class UmbracoExtensions
    {

        public static bool HasGridValue(this IPublishedContent contentItem, string alias)
        {
            try
            {
                if (contentItem.HasValue(alias))
                {
                    var stringValue = contentItem.GetPropertyValue<string>(alias);
                    if (!string.IsNullOrWhiteSpace(stringValue))
                    {
                        //var grid = contentItem.GetGridHtml("grid");
                        //// Strip html-tags
                        //Regex regex = new Regex("\\<[^\\>]*\\>");
                        //var text = regex.Replace(stringValue, String.Empty);

                        //if (text.Length > 0)
                        //{
                        //    return true;
                        //}


                        var grid = Json.Decode(stringValue);
               
                        if (grid.sections[0].rows[0].areas[0].controls[0].value.ToString().Trim().Length >= 1)
                        {
                            return true;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                //CustomLogHelper.Error<UmbracoViewPage>(e.Message, e);
            }


            return false;
        }

    }
}