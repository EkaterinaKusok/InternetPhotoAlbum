using System;
using System.Collections;
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
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                Roles = ToDalRoles(user.Roles)
            };
        }

        public static User ToOrmUser(this DalUser user)
        {
            return new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                Roles = ToOrmRoles(user.Roles)
            };
        }

        public static DalUserProfile ToDalUserProfile(this UserProfile userPr)
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
                Photos = ToDalPhotos(userPr.Photos)
            };
        }

        public static UserProfile ToOrmUserProfile(this DalUserProfile userPr)
        {
            byte[] tempPhoto = null;
            if (userPr.UserPhoto != null)
            {
                tempPhoto = new byte[userPr.UserPhoto.Length];
                userPr.UserPhoto.CopyTo(tempPhoto, 0);
            }
            return new UserProfile()
            {
                Id = userPr.Id,
                FirstName = userPr.FirstName,
                LastName = userPr.LastName,
                UserPhoto = tempPhoto,
                DateOfBirth = userPr.DateOfBirth,
                LastUpdateDate = userPr.LastUpdateDate,
                Photos = ToOrmPhotos(userPr.Photos)
            };
        }

        public static DalPhoto ToDalPhoto(this Photo photo)
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
                UserId = photo.UserProfileId,
                Ratings = ToDalRatings(photo.Ratings)
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto photo)
        {
            byte[] tempContent = null;
            if (photo.Image != null)
            {
                tempContent = new byte[photo.Image.Length];
                photo.Image.CopyTo(tempContent, 0);
            }

            return new Photo()
            {
                Id = photo.Id,
                Image = tempContent,
                Name = photo.Name,
                Description = photo.Description,
                UserProfileId = photo.UserId,
                Ratings = ToOrmRatings(photo.Ratings)
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

        public static DalRating ToDalRating(this Rating rating)
        {
            return new DalRating()
            {
                Id = rating.RatingId,
                UserRating = rating.UserRating,
                FromUserId = rating.UserProfileId,
                PhotoId = rating.PhotoId
            };
        }

        public static Rating ToOrmRating(this DalRating rating)
        {
            return new Rating()
            {
                RatingId = rating.Id,
                UserRating = rating.UserRating,
                UserProfileId = rating.FromUserId,
                PhotoId = rating.PhotoId
            };
        }

        private static ICollection<DalPhoto> ToDalPhotos(this ICollection<Photo> photos)
        {
            return photos.Select(photo => ToDalPhoto(photo)).ToList();
        }
        private static ICollection<Photo> ToOrmPhotos(this ICollection<DalPhoto> photos)
        {
            return photos.Select(photo => ToOrmPhoto(photo)).ToList();
        }
        private static ICollection<DalRole> ToDalRoles(this ICollection<Role> roles)
        {
            return roles.Select(role => ToDalRole(role)).ToList();
        }
        private static ICollection<Role> ToOrmRoles(this ICollection<DalRole> roles)
        {
            return roles.Select(role => ToOrmRole(role)).ToList();
        }
        private static ICollection<DalRating> ToDalRatings(this ICollection<Rating> ratings)
        {
            return ratings.Select(rating => ToDalRating(rating)).ToList();
        }
        private static ICollection<Rating> ToOrmRatings(this ICollection<DalRating> ratings)
        {
            return ratings.Select(rating => ToOrmRating(rating)).ToList();
        }
    }
}
