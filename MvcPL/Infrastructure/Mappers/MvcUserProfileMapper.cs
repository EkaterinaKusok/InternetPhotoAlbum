using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcUserProfileMapper
    {
        public static UserProfileModel ToMvcUserProfile(this UserProfileEntity userPr)
        {
            if (userPr == null)
                return null;
            byte[] tempPhoto = null;
            if (userPr.UserPhoto != null)
            {
                tempPhoto = new byte[userPr.UserPhoto.Length];
                userPr.UserPhoto.CopyTo(tempPhoto, 0);
            }
            return new UserProfileModel()
            {
                Id = userPr.Id,
                FirstName = userPr.FirstName,
                LastName = userPr.LastName,
                UserPhoto = tempPhoto,
                DateOfBirth = userPr.DateOfBirth,
                LastUpdateDate = userPr.LastUpdateDate
            };
        }

        public static UserProfileEntity ToBllUserProfile(this UserProfileModel userPr)
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