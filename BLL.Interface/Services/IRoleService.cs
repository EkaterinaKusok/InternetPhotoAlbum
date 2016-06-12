using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntityById(int id);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
        void UpdateRole(RoleEntity role);
    }
}