using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Concrete
{
    public static class DalMappers
    {
        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = DalMappers.ToDalRole(user.Role),
                Photos = DalMappers.ToDalPhotos(user.Photos)
            };
        }

        public static User ToOrmUser(this DalUser user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = DalMappers.ToOrmRole(user.Role),
                Photos = DalMappers.ToOrmPhotos(user.Photos)
            };
        }

        public static DalPhoto ToDalPhoto(this Photo photo)
        {
            byte[] tempContent;
            if (photo.Content != null)
            {
                tempContent = new byte[photo.Content.Length];
                photo.Content.CopyTo(tempContent, 0);
            }
            else tempContent = null;

            return new DalPhoto()
            {
                Id = photo.Id,
                Name = photo.Name,
                Description = photo.Description,
                Content = tempContent,
                UserId = photo.UserId
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto photo)
        {
            byte[] tempContent;
            if (photo.Content != null)
            {
                tempContent = new byte[photo.Content.Length];
                photo.Content.CopyTo(tempContent, 0);
            }
            else tempContent = null;

            return new Photo()
            {
                Id = photo.Id,
                Name = photo.Name,
                Description = photo.Description,
                Content = tempContent,
                UserId = photo.UserId
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static Role ToOrmRole(this DalRole role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static ICollection<DalPhoto> ToDalPhotos(this ICollection<Photo> photos)
        {
            return photos.Select(photo => DalMappers.ToDalPhoto(photo)).ToList();
        }

        public static ICollection<Photo> ToOrmPhotos(this ICollection<DalPhoto> photos)
        {
            return photos.Select(photo => DalMappers.ToOrmPhoto(photo)).ToList();
        }
    }
}
