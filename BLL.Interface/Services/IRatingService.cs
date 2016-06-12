using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRatingService
    {
        RatingEntity GetRatingEntityById(int id);
        IEnumerable<RatingEntity> GetAllRatingEntities();
        void CreateRating(RatingEntity rating);
        void DeleteRating(RatingEntity rating);
        void UpdateRating(RatingEntity rating);
    }
}
