using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            var model = _userService.GetAllUserEntities().Select(u => new UserViewModel()
            {
                Email = u.Email,
                CreationDate = u.CreationDate
            });

            //return System.Web.UI.WebControls.View(model);
            return View(model);
        }

        public ActionResult About()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                ViewBag.AuthType = User.Identity.AuthenticationType;
            }
            ViewBag.Login = User.Identity.Name;
            ViewBag.IsAdminInRole = User.IsInRole("Administrator") ?
                "You have administrator rights." : "You do not have administrator rights.";

            return View();
            //HttpContext.Profile["FirstName"] = "Вася";
            //HttpContext.Profile["LastName"] = "Иванов";
            //HttpContext.Profile.SetPropertyValue("Age",23);
            //Response.Write(HttpContext.Profile.GetPropertyValue("FirstName"));
            //Response.Write(HttpContext.Profile.GetPropertyValue("LastName"));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UsersEdit()
        {
            var model = _userService.GetAllUserEntities().Select(u => new UserViewModel()
            {
                Email = u.Email,
                CreationDate = u.CreationDate
            });

            return View(model);
            //return System.Web.UI.WebControls.View(model);
        }
    }
}