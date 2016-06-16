using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntityById(int id);
        void AddUserToRole(int userId, string roleName);
        IEnumerable<RoleEntity> GetUserRoles(int userId);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
        void UpdateRole(RoleEntity role);
    }
}