using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Helpers
{
    public static class ImageGalleryHelpers
    {
        public static MvcHtmlString SmallImage(this HtmlHelper html, byte[] image, string imageName = null)
        {
            if (image != null && image.Length != 0)
            {
                TagBuilder img = new TagBuilder("img");
                img.AddCssClass("img-responsive");
                img.MergeAttribute("style", "max-width:200px;max-height:200px;width:auto;height:auto");
                img.MergeAttribute("alt", imageName + " isn't loaded.");
                img.MergeAttribute("src", "data:image/jpeg;base64," + Convert.ToBase64String(image));
                return new MvcHtmlString(img.ToString());
            }
            else return new MvcHtmlString("Image doesn't exist.");
        }

        public static MvcHtmlString FullImage(this HtmlHelper html, byte[] image, string imageName = null)
        {
            if (image != null && image.Length != 0)
            {
                TagBuilder img = new TagBuilder("img");
                img.AddCssClass("img-responsive");
                img.MergeAttribute("style", "max-width:200px;max-height:200px;width:auto;height:auto");
                img.MergeAttribute("alt", imageName + " isn't loaded.");
                img.MergeAttribute("src", "data:image/jpeg;base64," + Convert.ToBase64String(image));
                return new MvcHtmlString(img.ToString());
            }
            else return new MvcHtmlString("Image doesn't exist.");
        }
    }
}


