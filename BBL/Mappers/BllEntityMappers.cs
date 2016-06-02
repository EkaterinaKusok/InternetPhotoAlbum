using System.Collections.Generic;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            ICollection<DalRole> tempRoles = new List<DalRole>();
            foreach (var current in userEntity.Roles)
            {
                tempRoles.Add(ToDalRole(current));
            }
            return new DalUser()
            {
                Id = userEntity.Id,
                Name = userEntity.UserName,
                Password = userEntity.UserPassword,
                Roles = tempRoles
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            ICollection<RoleEntity> tempRoles = new List<RoleEntity>();
            foreach (var current in dalUser.Roles)
            {
                tempRoles.Add(ToBllRole(current));
            }
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.Name,
                UserPassword = dalUser.Password,
                Roles = tempRoles
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
            return new DalPhoto()
            {
                Id = photoEntity.Id,
                Name = photoEntity.PhotoName,
                Description = photoEntity.Description,
                UserId = photoEntity.UserId
            };
        }

        public static PhotoEntity ToBllPhoto(this DalPhoto dalPhoto)
        {
            return new PhotoEntity()
            {
                Id = dalPhoto.Id,
                PhotoName = dalPhoto.Name,
                Description = dalPhoto.Description,
                UserId = dalPhoto.UserId
            };
        }
    }
}
