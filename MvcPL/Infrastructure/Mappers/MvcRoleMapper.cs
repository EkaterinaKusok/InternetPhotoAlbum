using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcRoleMapper
    {
        public static RoleModel ToMvcRole(this RoleEntity roleEntity)
        {
            if (roleEntity == null)
                return null;
            return new RoleModel()
            {
                Id = roleEntity.Id,
                RoleName = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        public static RoleEntity ToBllRole(this RoleModel roleModel)
        {
            if (roleModel == null)
                return null;
            return new RoleEntity()
            {
                Id = roleModel.Id,
                Name = roleModel.RoleName,
                Description = roleModel.Description
            };
        }
    }
}