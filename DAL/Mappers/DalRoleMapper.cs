using System.Collections.Generic;
using System.Linq;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalRoleMapper
    {
        public static DalRole ToDalRole(this Role role)
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

        public static Role ToOrmRole(this DalRole dalRole)
        {
            if (dalRole == null)
                return null;
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Description = dalRole.Description
            };
        }

        public static ICollection<DalRole> ToDalRoles(this ICollection<Role> roles)
        {
            return roles.Select(role => ToDalRole(role)).ToList();
        }

        public static ICollection<Role> ToOrmRoles(this ICollection<DalRole> dalRoles)
        {
            return dalRoles.Select(role => ToOrmRole(role)).ToList();
        }
    }
}
