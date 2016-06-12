using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                Roles = user.Roles.Select(ToDalRole).ToList()
            };
        }

        public static UserEntity ToBllUser(this DalUser user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                Roles = user.Roles.Select(ToBllRole).ToList()
            };
        }

        public static DalUserProfile ToDalUserProfile(this UserProfileEntity userPr)
        {
            byte[] tempPhoto = null;
            if (userPr.UserPhoto != null)
            {
                tempPhoto = new byte[userPr.UserPhoto.Length];
                userPr.UserPhoto.CopyTo(tempPhoto, 0);
            }
            return new DalUserProfile()
            {
                Id = userPr.Id,
                FirstName = userPr.FirstName,
                LastName = userPr.LastName,
                UserPhoto = tempPhoto,
                DateOfBirth = userPr.DateOfBirth,
                LastUpdateDate = userPr.LastUpdateDate,
                Photos = userPr.Photos.Select(ToDalPhoto).ToList()
            };
        }

        public static UserProfileEntity ToBllUserProfile(this DalUserProfile userPr)
        {
            byte[] tempPhoto = null;
            if (userPr.UserPhoto != null)
            {
                tempPhoto = new byte[userPr.UserPhoto.Length];
                userPr.UserPhoto.CopyTo(tempPhoto, 0);
            }
            return new UserProfileEntity()
            {
                Id = userPr.Id,
                FirstName = userPr.FirstName,
                LastName = userPr.LastName,
                UserPhoto = tempPhoto,
                DateOfBirth = userPr.DateOfBirth,
                LastUpdateDate = userPr.LastUpdateDate,
                Photos = userPr.Photos.Select(ToBllPhoto).ToList()
            };
        }

        public static DalPhoto ToDalPhoto(this PhotoEntity photo)
        {
            byte[] tempContent = null;
            if (photo.Image != null)
            {
                tempContent = new byte[photo.Image.Length];
                photo.Image.CopyTo(tempContent, 0);
            }

            return new DalPhoto()
            {
                Id = photo.Id,
                Image = tempContent,
                Name = photo.Name,
                Description = photo.Description,
                UserId = photo.UserId,
                Ratings = photo.Ratings.Select(ToDalRating).ToList()
            };
        }

        public static PhotoEntity ToBllPhoto(this DalPhoto photo)
        {
            byte[] tempContent = null;
            if (photo.Image != null)
            {
                tempContent = new byte[photo.Image.Length];
                photo.Image.CopyTo(tempContent, 0);
            }

            return new PhotoEntity()
            {
                Id = photo.Id,
                Image = tempContent,
                Name = photo.Name,
                Description = photo.Description,
                UserId = photo.UserId,
                Ratings = photo.Ratings.Select(ToBllRating).ToList()
            };
        }

        public static DalRole ToDalRole(this RoleEntity role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static RoleEntity ToBllRole(this DalRole role)
        {
            return new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static DalRating ToDalRating(this RatingEntity rating)
        {
            return new DalRating()
            {
                Id = rating.Id,
                UserRating = rating.UserRating,
                FromUserId = rating.FromUserId,
                PhotoId = rating.PhotoId
            };
        }

        public static RatingEntity ToBllRating(this DalRating rating)
        {
            return new RatingEntity()
            {
                Id = rating.Id,
                UserRating = rating.UserRating,
                FromUserId = rating.FromUserId,
                PhotoId = rating.PhotoId
            };
        }

    }
}
