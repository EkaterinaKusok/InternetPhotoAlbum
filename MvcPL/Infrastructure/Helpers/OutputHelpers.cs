using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Infrastructure.Helpers
{
    public static class OutputHelpers
    {
        public static MvcHtmlString OutputDateTime(this HtmlHelper html, DateTime? dateTime)
        {
            TagBuilder divFormGroup = new TagBuilder("div");
            if (dateTime != null)
            {
                TagBuilder p = new TagBuilder("p");
                p.SetInnerText(((DateTime) dateTime).ToShortDateString()); //.ToString("d")
                divFormGroup.InnerHtml += p.ToString();
            }
            else
            {
                divFormGroup.InnerHtml += new TagBuilder("br");
                TagBuilder p = new TagBuilder("p");
                p.AddCssClass("text-muted text-left");
                p.SetInnerText("Don't set date of birth");
                divFormGroup.InnerHtml += p.ToString();
            }
            return new MvcHtmlString(divFormGroup.ToString());
        }
        public static MvcHtmlString OutputDateTimeForTable(this HtmlHelper html, DateTime? dateTime)
        {
            if (dateTime != null)
                return new MvcHtmlString(" "+((DateTime)dateTime).ToShortDateString());
            else
                return new MvcHtmlString(" Don't set this value");
        }
        public static MvcHtmlString OutputUserAvatar(this HtmlHelper html, byte[] avatar)
        {
            TagBuilder divFormGroup = new TagBuilder("div");
            if (avatar != null && avatar.Length!=0)
            {
                TagBuilder img = new TagBuilder("img");  
                img.MergeAttribute("src","data:image/jpeg;base64,"+Convert.ToBase64String(avatar));
                img.MergeAttribute("style", "max-width:250px;max-height:150px;width:auto;height:auto");
                divFormGroup.InnerHtml += img.ToString();
            }
            else
            {
                divFormGroup.InnerHtml += new TagBuilder("br");
                TagBuilder p = new TagBuilder("p");
                p.AddCssClass("text-muted text-center");
                p.SetInnerText("No photo");
                divFormGroup.InnerHtml += p.ToString();
            }
            return new MvcHtmlString(divFormGroup.ToString());
        }

        public static MvcHtmlString OutputSmallUserAvatar(this HtmlHelper html, byte[] avatar)
        {
            TagBuilder divFormGroup = new TagBuilder("div");
            if (avatar != null && avatar.Length != 0)
            {
                TagBuilder img = new TagBuilder("img"); 
                img.MergeAttribute("src", "data:image/jpeg;base64," + Convert.ToBase64String(avatar));
                img.MergeAttribute("style", "max-width:50%;max-height:100pt;width:auto;height:auto");
                divFormGroup.InnerHtml += img.ToString();
            }
            else
            {
                TagBuilder h6 = new TagBuilder("h4");
                h6.AddCssClass("text-muted text-lefr");
                h6.SetInnerText("No photo");
                divFormGroup.InnerHtml += h6.ToString();
                divFormGroup.InnerHtml += new TagBuilder("br");
            }
            return new MvcHtmlString(divFormGroup.ToString());
        }

        public static MvcHtmlString OutputRoleList(this HtmlHelper html, IEnumerable<string> roles)
        {
            TagBuilder divGroup = new TagBuilder("div");
            TagBuilder divCol5 = new TagBuilder("div");
            divCol5.SetInnerText("Roles:");
            divGroup.InnerHtml += divCol5.ToString();
            TagBuilder divCol7 = new TagBuilder("div");
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }
            divCol7.InnerHtml += ul.ToString();
            divGroup.InnerHtml += divCol7.ToString();
            return new MvcHtmlString(divGroup.ToString());
        }
    }
}
