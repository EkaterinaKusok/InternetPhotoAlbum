using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository: IRepository<DalRole>
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalRole> GetAll()
        {
            var roles = context.Set<Role>().Select(role => role).ToList();
            return roles.Select(role=>DalMappers.ToDalRole(role));
        }

        public DalRole GetById(int key)
        {
            var ormrole = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            return ormrole.ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole e)
        {
            var role = e.ToOrmRole();
            context.Set<Role>().Add(role);
        }

        public void Delete(DalRole ph)
        {
            var role = ph.ToOrmRole();
            role = context.Set<Role>().Single(u => u.Id == role.Id);
            context.Set<Role>().Remove(role); ;
        }

        public void Update(DalRole entity)
        {
            var role = entity.ToOrmRole();
            Role oldrole = context.Set<Role>().Single(u => u.Id == role.Id);
            context.Set<Role>().AddOrUpdate(oldrole, role);
        }
    }
}
