using System.Web.Mvc;
using System.Web.Services;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

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
        public void AddOrUpdateRating(string userName, int photoId, int rating)
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
            return;
        }

        [ChildActionOnly]
        public void DeleteRating(string userName, int photoId, int rating)
        {
            UserModel currentUser = userService.GetUserEntityByEmail(userName).ToMvcUser();
            RatingModel userRating = ratingService.GetUserRatingOfPhoto(currentUser.Id, photoId).ToMvcRating();

            if (userRating != null && userRating.UserRating==rating)
            {
                ratingService.DeleteRating(userRating.ToBllRating());
            }

            return;
        }
    }
}