using System.Web.Mvc;
using System.Web.Services;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using NonActionAttribute = System.Web.Http.NonActionAttribute;

namespace MvcPL.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        private readonly IUserService userService;
        private readonly IRatingService ratingService;

        public RatingController(IUserService userService, IRatingService ratingService)
        {
            this.userService = userService;
            this.ratingService = ratingService;
        }

        [ChildActionOnly]
        public ActionResult AddOrUpdateRating(string userName, int photoId, int rating)
        {
            UserModel currentUser = userService.GetUserEntityByEmail(userName).ToMvcUser();
            RatingModel userRating = ratingService.GetUserRatingOfPhoto(currentUser.Id, photoId).ToMvcRating();

            if (userRating == null)
            {
                userRating = new RatingModel
                {
                    PhotoId = photoId,
                    FromUserId = currentUser.Id,
                    UserRating = rating
                };
                ratingService.CreateRating(userRating.ToBllRating());
            }
            else
            {
                userRating.UserRating = rating;
                ratingService.UpdateRating(userRating.ToBllRating());
            }
            return new EmptyResult();
        }

        [ChildActionOnly]
        public ActionResult DeleteRating(string userName, int photoId, int rating)
        {
            UserModel currentUser = userService.GetUserEntityByEmail(userName).ToMvcUser();
            RatingModel userRating = ratingService.GetUserRatingOfPhoto(currentUser.Id, photoId).ToMvcRating();

            if (userRating != null && userRating.UserRating==rating)
            {
                ratingService.DeleteRating(userRating.ToBllRating());
            }

            return new EmptyResult();
        }
    }
}