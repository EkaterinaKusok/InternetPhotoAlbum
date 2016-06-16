using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalUserProfileMapper
    {
        public static DalUserProfile ToDalUserProfile(this UserProfile userPr)
        {
            if (userPr == null)
                return null;
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
                //Photos = ToDalPhotos(userPr.Photos)
            };
        }

        public static UserProfile ToOrmUserProfile(this DalUserProfile dalUserPr)
        {
            if (dalUserPr == null)
                return null;
            byte[] tempPhoto = null;
            if (dalUserPr.UserPhoto != null)
            {
                tempPhoto = new byte[dalUserPr.UserPhoto.Length];
                dalUserPr.UserPhoto.CopyTo(tempPhoto, 0);
            }
            return new UserProfile()
            {
                Id = dalUserPr.Id,
                FirstName = dalUserPr.FirstName,
                LastName = dalUserPr.LastName,
                UserPhoto = tempPhoto,
                DateOfBirth = dalUserPr.DateOfBirth,
                LastUpdateDate = dalUserPr.LastUpdateDate,
                //Photos = ToOrmPhotos(dalUserPr.Photos)
            };
        }
    }
}
