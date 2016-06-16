using System.Collections.Generic;
using System.Linq;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalPhotoMapper
    {
        public static DalPhoto ToDalPhoto(this Photo photo)
        {
            if (photo == null)
                return null;
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
                TotalRating = photo.TotalRating,
                CreationDate = photo.CreationDate
                //Ratings = ToDalRatings(dalPhoto.Ratings)
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto dalPhoto)
        {
            if (dalPhoto == null)
                return null;
            byte[] tempContent = null;
            if (dalPhoto.Image != null)
            {
                tempContent = new byte[dalPhoto.Image.Length];
                dalPhoto.Image.CopyTo(tempContent, 0);
            }

            return new Photo()
            {
                Id = dalPhoto.Id,
                Image = tempContent,
                Name = dalPhoto.Name,
                Description = dalPhoto.Description,
                UserProfileId = dalPhoto.UserId,
                TotalRating = dalPhoto.TotalRating,
                CreationDate = dalPhoto.CreationDate
                //Ratings = ToOrmRatings(dalPhoto.Ratings)
            };
        }

        public static ICollection<DalPhoto> ToDalPhotos(this ICollection<Photo> photos)
        {
            return photos.Select(photo => ToDalPhoto(photo)).ToList();
        }

        public static ICollection<Photo> ToOrmPhotos(this ICollection<DalPhoto> dalPhotos)
        {
            return dalPhotos.Select(photo => ToOrmPhoto(photo)).ToList();
        }
    }
}
