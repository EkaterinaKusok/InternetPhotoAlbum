using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().AsEnumerable().Select(role => role.ToDalRole());
        }

        public DalRole GetById(int key)
        {
            return context.Set<Role>().FirstOrDefault(role => role.Id == key)?.ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole dalRole)
        {
            context.Set<Role>().Add(dalRole.ToOrmRole());
        }

        public void Delete(DalRole dalRole)
        {
            Role role = context.Set<Role>().FirstOrDefault(r => r.Id == dalRole.Id);
            if (role!=null)
                context.Set<Role>().Remove(role);
        }

        public void Update(DalRole dalRole)
        {
            Role oldRole = context.Set<Role>().FirstOrDefault(u => u.Id == dalRole.Id);
            if (oldRole != null)
            {
                oldRole.Name = dalRole.Name;
                oldRole.Description = dalRole.Description;
            }
            else
                context.Set<Role>().Add(dalRole.ToOrmRole());
        }

        public void AddUserToRole(int userId, string roleName)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                Role role = context.Set<Role>().FirstOrDefault(r => r.Name == roleName);
                if (role != null)
                    role.Users.Add(user);
            }
        }

        public IEnumerable<DalRole> GetUserRoles(int userId)
        {
            return context.Set<User>().FirstOrDefault(user => user.Id == userId)?.Roles.ToDalRoles();
        }
    }
}
