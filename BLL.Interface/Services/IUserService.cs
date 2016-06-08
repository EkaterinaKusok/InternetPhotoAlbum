using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        void UpdateUser(UserEntity user);
        RoleEntity GetUserRole(int id);
        ICollection<PhotoEntity> GetUserPhotos(int id);
        //etc.
    }
}