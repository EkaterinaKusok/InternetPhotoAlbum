using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcUserMapper
    {
        public static UserModel ToMvcUser(this UserEntity userEntity)
        {
            if (userEntity == null)
                return null;
            return new UserModel()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate
            };
        }

        public static UserEntity ToBllUser(this UserModel userModel)
        {
            if (userModel == null)
                return null;
            return new UserEntity()
            {
                Id = userModel.Id,
                Email = userModel.Email,
                Password = userModel.Password,
                CreationDate = userModel.CreationDate
            };
        }
    }
}