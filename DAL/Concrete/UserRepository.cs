using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            
            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId
            });
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return new DalUser()
            {
                Id = ormuser.Id,
                Name = ormuser.Name,
                Password = ormuser.Password,
                RoleId = ormuser.RoleId
            };
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Name = e.Name,
                Password = e.Password,
                RoleId = e.RoleId
            };
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            var user = new User()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                RoleId = e.RoleId
            };
            user = context.Set<User>().Single(u => u.Id == user.Id); // catch exception
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            var user = new User()
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password,
                RoleId = entity.RoleId
            };
            User oldUser = context.Set<User>().Single(u => u.Id == user.Id); // catch except and check that user in table
           // context.Set<User>().Remove(oldUser);
           // context.Set<User>().Add(user);
            context.Set<User>().AddOrUpdate(oldUser, user);
        }


        public DalRole GetRole(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            Role role = ormuser.Role;
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public ICollection<DalPhoto> GetPhotosByUserId(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            ICollection<Photo> photos = ormuser.Photos.ToList();
            return photos.Select(photo => ToDalPhoto(photo)).ToList();
        }

        private DalPhoto ToDalPhoto(Photo photo)
        {
            //byte[] tempContent = new byte[photo.Content.Length];
            byte[] tempContent = null;
            //photo.Content.CopyTo(tempContent, 0);
            return new DalPhoto()
            {
                Id = photo.Id,
                Name = photo.Name,
                Description = photo.Description,
                Content = tempContent,
                UserId = photo.UserId
            };
        }
    }
}