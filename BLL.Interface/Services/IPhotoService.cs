using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IPhotoService
    {
        PhotoEntity GetPhotoEntityById(int id);
        IEnumerable<PhotoEntity> GetAllPhotoEntities();
        IEnumerable<PhotoEntity> GetUserPhotos(int userId);
        void SetTotalRating(int photoId, int totalRating);
        void CreatePhoto(PhotoEntity photo);
        void DeletePhoto(PhotoEntity photo);
        void UpdatePhoto(PhotoEntity photo);
    }
}
