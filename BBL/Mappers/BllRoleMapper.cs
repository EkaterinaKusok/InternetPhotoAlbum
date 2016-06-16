using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllRoleMapper
    {
        public static DalRole ToDalRole(this RoleEntity role)
        {
            if (role == null)
                return null;
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static RoleEntity ToBllRole(this DalRole role)
        {
            if (role == null)
                return null;
            return new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }
    }
}
