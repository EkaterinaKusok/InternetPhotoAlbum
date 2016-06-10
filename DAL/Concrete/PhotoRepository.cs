using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
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
            var photos = context.Set<Photo>().Select(photo=>photo).ToList();
            return photos.Select(photo=>DalMappers.ToDalPhoto(photo));
        }

        public DalPhoto GetById(int key)
        {
            var ormPhoto = context.Set<Photo>().FirstOrDefault(photo => photo.Id == key);
            return ormPhoto.ToDalPhoto();
        }

        public DalPhoto GetByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalPhoto e)
        {
            var photo = e.ToOrmPhoto();
            context.Set<Photo>().Add(photo);
        }

        public void Delete(DalPhoto ph)
        {
            var photo = ph.ToOrmPhoto();
            photo = context.Set<Photo>().Single(u => u.Id == photo.Id); 
            context.Set<Photo>().Remove(photo); ;
        }

        public void Update(DalPhoto entity)
        {
            var photo = entity.ToOrmPhoto();
            Photo oldPhoto = context.Set<Photo>().Single(u => u.Id == photo.Id);
            context.Set<Photo>().AddOrUpdate(oldPhoto, photo);
        }

    }

}
