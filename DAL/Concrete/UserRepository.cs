using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            var users = context.Set<User>().Select(user => user).ToList();
            return users.Select(user => DalMappers.ToDalUser(user));
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return ormuser.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser e)
        {
            var user = e.ToOrmUser();
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            var user = e.ToOrmUser();
            user = context.Set<User>().Single(u => u.Id == user.Id); // catch exception
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            var user = entity.ToOrmUser();
            User oldUser = context.Set<User>().Single(u => u.Id == user.Id); // catch except and check that user in table
           // context.Set<User>().Remove(oldUser);
           // context.Set<User>().Add(user);
            context.Set<User>().AddOrUpdate(oldUser, user);
        }
    }
}