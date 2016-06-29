using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcPL.Models.ViewModels;

namespace MvcPL.Helpers
{
    public static class UserHelper
    {
        public static MvcHtmlString ShowUsers(this HtmlHelper html, IEnumerable<UserViewModel> users)
        {
            TagBuilder div = new TagBuilder("div");
            if (users != null)
            {
                foreach (var user in users)
                {
                    TagBuilder divRow = new TagBuilder("div");
                    divRow.AddCssClass("raw");
                    TagBuilder a = new TagBuilder("a");
                    a.MergeAttribute("href", "/Home/Index/@user.Email");
                    TagBuilder div2 = new TagBuilder("div");
                    div2.AddCssClass("col-md-2");
                    if (user.Profile.UserPhoto != null)
                    {
                        TagBuilder img = new TagBuilder("img");
                        img.MergeAttribute("style", "max-width: 100%;");
                        img.MergeAttribute("src", "data:image/jpeg;base64,"+Convert.ToBase64String(user.Profile.UserPhoto));
                        div2.InnerHtml += img.ToString();
                    }
                    else
                    {
                        div2.InnerHtml += (new TagBuilder("/br")).ToString();
                        TagBuilder p = new TagBuilder("p");
                        p.AddCssClass("text-muted text-center");
                        p.SetInnerText("No photo");
                        div2.InnerHtml += p.ToString();
                    }
                    a.InnerHtml += div2.ToString();

                    TagBuilder div5 = new TagBuilder("div");
                    div5.AddCssClass("col-md-5");
                    TagBuilder h4 = new TagBuilder("h4");
                    h4.SetInnerText(user.Profile.FirstName+" "+user.Profile.LastName);
                    div5.InnerHtml+=h4.ToString();

                    if (user.Profile.DateOfBirth != null)
                    {
                        TagBuilder p = new TagBuilder("p");
                        p.SetInnerText(((DateTime) user.Profile.DateOfBirth).ToShortTimeString());
                        div5.InnerHtml += p.ToString();
                    }
                    else
                    {
                        div5.InnerHtml += (new TagBuilder("/br")).ToString();
                        TagBuilder p = new TagBuilder("p");
                        p.AddCssClass("text-muted text-center");
                        p.SetInnerText("Don't set date of birth");
                        div5.InnerHtml += p.ToString();
                    }
                    a.InnerHtml += div5.ToString(); 
                    divRow.InnerHtml+=a.ToString(); //close a

                    div2 = new TagBuilder("div");
                    div2.AddCssClass("col-md-2");
                    div2.SetInnerText(user.User.CreationDate.ToShortDateString());
                    divRow.InnerHtml+=div2.ToString();
                    TagBuilder div3 = new TagBuilder("div");
                    div3.AddCssClass("col-md-3");
                    div3.InnerHtml+= LinkExtensions.ActionLink(html,"Edit", "UserEdit", new { id = user.User.Id});
                    //div3.InnerHtml+= Html.ActionLink(("Delete", "DeleteUser", new { id = user.Id})
                    divRow.InnerHtml+=div3.ToString();
                    //divRow.InnerHtml += (new TagBuilder("/br")).ToString();
                    div.InnerHtml += divRow.ToString();
                }
            }
            return new MvcHtmlString(div.ToString());
        }
    }
}
