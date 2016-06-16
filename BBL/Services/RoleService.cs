using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class RoleService: IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public RoleEntity GetRoleEntityById(int id)
        {
            return roleRepository.GetById(id)?.ToBllRole();
        }

        public void AddUserToRole(int userId, string roleName)
        {
            roleRepository.AddUserToRole(userId, roleName);
        }

        public IEnumerable<RoleEntity> GetUserRoles(int userId)
        {
            return roleRepository.GetUserRoles(userId).Select(role => role.ToBllRole());
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(r => r.ToBllRole());
        }

        public void CreateRole(RoleEntity role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            roleRepository.Delete(role.ToDalRole());
            uow.Commit();
        }

        public void UpdateRole(RoleEntity role)
        {
            roleRepository.Update(role.ToDalRole());
            uow.Commit();
        }
    }
}
