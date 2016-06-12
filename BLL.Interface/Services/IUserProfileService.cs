using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IUserProfileService
    {
        UserProfileEntity GetUserProfileEntityById(int id);
        IEnumerable<UserProfileEntity> GetAllUserProfileEntities();
        void CreateUserProfile(UserProfileEntity profile);
        void DeleteUserProfile(UserProfileEntity profile);
        void UpdateUserProfile(UserProfileEntity profile);
    }
}
