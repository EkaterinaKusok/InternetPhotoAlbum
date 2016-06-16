using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcRatingMapper
    {
        public static RatingModel ToMvcRating(this RatingEntity ratingEntity)
        {
            if (ratingEntity == null)
                return null;
            return new RatingModel()
            {
                Id = ratingEntity.Id,
                UserRating = ratingEntity.UserRating,
                FromUserId = ratingEntity.FromUserId,
                PhotoId = ratingEntity.PhotoId
            };
        }

        public static RatingEntity ToBllRating(this RatingModel ratingModel)
        {
            if (ratingModel == null)
                return null;
            return new RatingEntity()
            {
                Id = ratingModel.Id,
                UserRating = ratingModel.UserRating,
                FromUserId = ratingModel.FromUserId,
                PhotoId = ratingModel.PhotoId
            };
        }
    }
}