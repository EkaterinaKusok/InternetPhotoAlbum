using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRatingService
    {
        RatingEntity GetRatingEntityById(int id);
        RatingEntity GetUserRatingOfPhoto(int userId, int photoId);
        IEnumerable<RatingEntity> GetAllRatingEntities();
        IEnumerable<RatingEntity> GetPhotoRatings(int photoId);
        void CreateRating(RatingEntity rating);
        void DeleteRating(RatingEntity rating);
        void UpdateRating(RatingEntity rating);
        int CountTotalRating(int photoId);
    }
}
