using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllRatingMapper
    {
        public static DalRating ToDalRating(this RatingEntity rating)
        {
            if (rating == null)
                return null;
            return new DalRating()
            {
                Id = rating.Id,
                UserRating = rating.UserRating,
                FromUserId = rating.FromUserId,
                PhotoId = rating.PhotoId
            };
        }

        public static RatingEntity ToBllRating(this DalRating rating)
        {
            if (rating == null)
                return null;
            return new RatingEntity()
            {
                Id = rating.Id,
                UserRating = rating.UserRating,
                FromUserId = rating.FromUserId,
                PhotoId = rating.PhotoId
            };
        }
    }
}
