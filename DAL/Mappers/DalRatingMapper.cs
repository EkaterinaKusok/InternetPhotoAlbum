using System.Collections.Generic;
using System.Linq;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalRatingMapper
    {
        public static DalRating ToDalRating(this Rating rating)
        {
            if (rating == null)
                return null;
            return new DalRating()
            {
                Id = rating.RatingId,
                UserRating = rating.UserRating,
                FromUserId = rating.UserProfileId,
                PhotoId = rating.PhotoId
            };
        }

        public static Rating ToOrmRating(this DalRating dalRating)
        {
            if (dalRating == null)
                return null;
            return new Rating()
            {
                RatingId = dalRating.Id,
                UserRating = dalRating.UserRating,
                UserProfileId = dalRating.FromUserId,
                PhotoId = dalRating.PhotoId
            };
        }

        private static ICollection<DalRating> ToDalRatings(this ICollection<Rating> ratings)
        {
            return ratings.Select(rating => ToDalRating(rating)).ToList();
        }
        private static ICollection<Rating> ToOrmRatings(this ICollection<DalRating> dalRatings)
        {
            return dalRatings.Select(rating => ToOrmRating(rating)).ToList();
        }
    }
}
