using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DbContext context;

        public PhotoRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return context.Set<Photo>().AsEnumerable().Select(photo => photo.ToDalPhoto());
        }

        public DalPhoto GetById(int key)
        {
            return context.Set<Photo>().FirstOrDefault(photo => photo.Id == key)?.ToDalPhoto();
        }

        public DalPhoto GetByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalPhoto dalPhoto)
        {
            context.Set<Photo>().Add(dalPhoto.ToOrmPhoto());
        }

        public void Delete(DalPhoto dalPhoto)
        {
            Photo photo = context.Set<Photo>().FirstOrDefault(ph => ph.Id == dalPhoto.Id); 
            context.Set<Photo>().Remove(photo); ;
        }

        public void Update(DalPhoto dalPhoto)
        {
            Photo photo = context.Set<Photo>().FirstOrDefault(ph => ph.Id == dalPhoto.Id);
            if (photo != null)
            {
                photo.Image = dalPhoto.Image;
                photo.Name = dalPhoto.Name;
                photo.Description = dalPhoto.Description;
                photo.UserProfileId = dalPhoto.UserId;
                photo.TotalRating = dalPhoto.TotalRating;
            }
            else
                context.Set<Photo>().Add(dalPhoto.ToOrmPhoto());
        }

        public IEnumerable<DalPhoto> GetUserPhotos(int userId)
        {
            return context.Set<UserProfile>().FirstOrDefault(u => u.Id == userId)?.Photos.ToDalPhotos();
        }

        public void SetTotalRating(int photoId, int totalRating)
        {
            Photo photo = context.Set<Photo>().FirstOrDefault(ph => ph.Id == photoId);
            if (photo != null)
            {
                photo.TotalRating = totalRating;
            }
        }
    }

}
