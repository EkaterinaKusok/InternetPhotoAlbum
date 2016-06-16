using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IPhotoRepository : IRepository<DalPhoto>
    {
        IEnumerable<DalPhoto> GetUserPhotos(int userId);
        void SetTotalRating(int photoId,int totalRating);
    }
}
