using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Name = userEntity.UserName,
                Password = userEntity.UserPassword,
                RoleId = userEntity.UserRoleId,
                //Roles = userEntity.Roles.Select(ToDalRole).ToList(),
                //Photos = userEntity.Photos.Select(ToDalPhoto).ToList()
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.Name,
                UserPassword = dalUser.Password,
                UserRoleId = dalUser.RoleId
                //Roles = dalUser.Roles.Select(ToBllRole).ToList(),
                //Photos = dalUser.Photos.Select(ToBllPhoto).ToList()
            };
        }

        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Description = dalRole.Description

            };
        }

        public static DalPhoto ToDalPhoto(this PhotoEntity photoEntity)
        {
            byte[] tempContent = new byte[photoEntity.Content.Length];
            photoEntity.Content.CopyTo(tempContent, 0);
            return new DalPhoto()
            {
                Id = photoEntity.Id,
                Name = photoEntity.PhotoName,
                Description = photoEntity.Description,
                Content = tempContent,
                UserId = photoEntity.UserId
            };
        }

        public static PhotoEntity ToBllPhoto(this DalPhoto dalPhoto)
        {
            //byte[] tempContent = new byte[dalPhoto.Content.Length];
            //dalPhoto.Content.CopyTo(tempContent, 0);
            return new PhotoEntity()
            {
                Id = dalPhoto.Id,
                PhotoName = dalPhoto.Name,
                Description = dalPhoto.Description,
                Content = null,//tempContent,
                UserId = dalPhoto.UserId
            };
        }

        public static ICollection<PhotoEntity> ToBllPhotos(this ICollection<DalPhoto> dalPhotos)
        {
            ICollection<PhotoEntity> bllPhotos = new List<PhotoEntity>();
            foreach (var dalPhoto in dalPhotos)
            {
                bllPhotos.Add(ToBllPhoto(dalPhoto));
            }
            return bllPhotos;
        }
    }
}
