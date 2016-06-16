using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class PhotoService: IPhotoService
    {
        private readonly IUnitOfWork uow;
        private readonly IPhotoRepository photoRepository;

        public PhotoService(IUnitOfWork uow, IPhotoRepository repository)
        {
            this.uow = uow;
            this.photoRepository = repository;
        }

        public PhotoEntity GetPhotoEntityById(int id)
        {
            return photoRepository.GetById(id)?.ToBllPhoto();
        }

        public IEnumerable<PhotoEntity> GetAllPhotoEntities()
        {
            return photoRepository.GetAll().Select(photo => photo.ToBllPhoto());
        }

        public IEnumerable<PhotoEntity> GetUserPhotos(int userId)
        {
            return photoRepository.GetUserPhotos(userId).Select(photo => photo.ToBllPhoto());
        }

        public void SetTotalRating(int photoId, int totalRating)
        {
            photoRepository.SetTotalRating(photoId,totalRating);
            uow.Commit();
        }

        public void CreatePhoto(PhotoEntity photo)
        {
            photoRepository.Create(photo.ToDalPhoto());
            uow.Commit();
        }

        public void DeletePhoto(PhotoEntity photo)
        {
            photoRepository.Delete(photo.ToDalPhoto());
            uow.Commit();
        }

        public void UpdatePhoto(PhotoEntity photo)
        {
            photoRepository.Update(photo.ToDalPhoto());
            uow.Commit();
        }
    }
}
