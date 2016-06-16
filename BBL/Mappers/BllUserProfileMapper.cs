using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllUserProfileMapper
    {
        public static DalUserProfile ToDalUserProfile(this UserProfileEntity userPr)
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
                LastUpdateDate = userPr.LastUpdateDate
            };
        }

        public static UserProfileEntity ToBllUserProfile(this DalUserProfile userPr)
        {
            if (userPr == null)
                return null;
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
                LastUpdateDate = userPr.LastUpdateDate
            };
        }
    }
}
