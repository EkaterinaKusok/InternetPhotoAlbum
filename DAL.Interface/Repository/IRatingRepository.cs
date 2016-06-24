using System;
using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IRatingRepository: IRepository<DalRating>
    {
        IEnumerable<DalRating> GetPhotoRatings(int photoId);
        int CountTotalRating(int photoId);
        DalRating GetUserRatingOfPhoto(int userId, int photoId);
    }
}
