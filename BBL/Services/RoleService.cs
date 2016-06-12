using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class RoleService: IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalRole> roleRepository;

        public RoleService(IUnitOfWork uow, IRepository<DalRole> repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public RoleEntity GetRoleEntityById(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
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
