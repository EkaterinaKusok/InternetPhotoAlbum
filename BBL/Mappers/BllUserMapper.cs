using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        public static DalUser ToDalUser(this UserEntity user)
        {
            if (user == null)
                return null;
            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate
            };
        }

        public static UserEntity ToBllUser(this DalUser user)
        {
            if (user == null)
                return null;
            return new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate
            };
        }
    }
}
