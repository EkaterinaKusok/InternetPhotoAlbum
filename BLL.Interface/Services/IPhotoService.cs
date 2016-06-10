using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IPhotoService
    {
        PhotoEntity GetPhotoEntityById(int id);
        IEnumerable<PhotoEntity> GetAllPhotoEntities();
        void CreatePhoto(PhotoEntity photo);
        void DeletePhoto(PhotoEntity photo);
        void UpdatePhoto(PhotoEntity photo);
    }
}
