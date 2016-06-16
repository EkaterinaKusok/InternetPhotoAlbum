using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllPhotoMapper
    {
        public static DalPhoto ToDalPhoto(this PhotoEntity photo)
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
                UserId = photo.UserId,
                TotalRating = photo.TotalRating,
                CreationDate = photo.CreationDate
            };
        }

        public static PhotoEntity ToBllPhoto(this DalPhoto photo)
        {
            if (photo == null)
                return null;
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
                TotalRating = photo.TotalRating,
                CreationDate = photo.CreationDate
            };
        }
    }
}
