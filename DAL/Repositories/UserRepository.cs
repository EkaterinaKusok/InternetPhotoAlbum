using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
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
            //var users = context.Set<User>().Select(user => user).ToList();
            //return users.Select(user => user.ToDalUser());
            return context.Set<User>().Select(user => user).ToList().Select(user => user.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            return context.Set<User>().FirstOrDefault(user => user.Id == key)?.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser dalUser)
        {
            context.Set<User>().Add(dalUser.ToOrmUser());
            //var user = new User()
            //{
            //    Email = e.Email,
            //    Password = e.Password,
            //    CreationDate = e.CreationDate
            //    //Roles = e.Roles.ToOrmRoles()
            //};
            //context.Set<User>().Add(user);

        }

        public void Delete(DalUser dalUser)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Id == dalUser.Id); // catch exception
            if (user != null)
            {
                UserProfile userProfile = context.Set<UserProfile>().FirstOrDefault(u => u.Id == user.Id);
                if (userProfile != null)
                {
                    var ratings = userProfile.Ratings?.ToList();
                    if (ratings != null)
                        for (int i = 0; i < ratings.Count; i++)
                            ratings[i].UserProfileId = null;
                    context.Set<UserProfile>().Remove(userProfile);
                    context.Set<User>().Remove(user);
                }
            }
        }

        public void Update(DalUser dalUser)
        {
            User oldUser = context.Set<User>().FirstOrDefault(u => u.Id == dalUser.Id);
            if (oldUser != null)
            {
                oldUser.Email = dalUser.Email;
                oldUser.Password = dalUser.Password;
            }
            else
                context.Set<User>().Add(dalUser.ToOrmUser());
        }

        public DalUser GetUserByEmail(string email)
        {
            return context.Set<User>().FirstOrDefault(user => user.Email.Equals(email))?.ToDalUser();
        }
    }
}