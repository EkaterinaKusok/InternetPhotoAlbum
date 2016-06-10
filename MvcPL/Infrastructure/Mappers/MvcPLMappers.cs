using MvcPL.Models;
using BLL.Interfacies.Entities;
using System.Linq;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static UserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                Password = userEntity.UserPassword,
                RoleId = userEntity.UserRoleId,
                UserRoleName = userEntity.UserRole.Name,
                UserRole = ToMvcRole(userEntity.UserRole),
                UserPhotos = userEntity.Photos.Select(ToMvcPhoto).ToList()
            };
        }

        public static UserEntity ToBllUser(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                UserPassword = userViewModel.Password,
                UserRoleId = userViewModel.UserRole.Id,
                UserRole = ToBllRole(userViewModel.UserRole),
                Photos = userViewModel.UserPhotos.Select(ToBllPhoto).ToList()
            };
        }

        public static RoleModel ToMvcRole(this RoleEntity roleEntity)
        {
            return new RoleModel()
            {
                Id = roleEntity.Id,
                RoleName = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        public static RoleEntity ToBllRole(this RoleModel roleModel)
        {
            return new RoleEntity()
            {
                Id = roleModel.Id,
                Name = roleModel.RoleName,
                Description = roleModel.Description
            };
        }

        public static PhotoModel ToMvcPhoto(this PhotoEntity photoEntity)
        {
            byte[] tempContent;
            if (photoEntity.Content != null)
            {
                tempContent = new byte[photoEntity.Content.Length];
                photoEntity.Content.CopyTo(tempContent, 0);
            }
            else tempContent = null;
            return new PhotoModel()
            {
                Id = photoEntity.Id,
                PhotoName = photoEntity.PhotoName,
                PhotoDescription = photoEntity.Description,
                Image = tempContent,
                UserId = photoEntity.UserId
            };
        }

        public static PhotoEntity ToBllPhoto(this PhotoModel mvcPhoto)
        {
            byte[] tempContent;
            if (mvcPhoto.Image != null)
            {
                tempContent = new byte[mvcPhoto.Image.Length];
                mvcPhoto.Image.CopyTo(tempContent, 0);
            }
            else tempContent = null;
            return new PhotoEntity()
            {
                Id = mvcPhoto.Id,
                PhotoName = mvcPhoto.PhotoName,
                Description = mvcPhoto.PhotoDescription,
                Content = tempContent,
                UserId = mvcPhoto.UserId
            };
        }
    }
}