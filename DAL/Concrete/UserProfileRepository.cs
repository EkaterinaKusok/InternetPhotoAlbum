using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserProfileRepository: IRepository<DalUserProfile>
    {
        private readonly DbContext context;

        public UserProfileRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUserProfile> GetAll()
        {
            var profiles = context.Set<UserProfile>().Select(p => p).ToList();
            return profiles.Select(p => DalMappers.ToDalUserProfile(p));
        }

        public DalUserProfile GetById(int key)
        {
            var ormProfile = context.Set<UserProfile>().FirstOrDefault(p => p.Id == key);
            return ormProfile.ToDalUserProfile();
        }

        public DalUserProfile GetByPredicate(Expression<Func<DalUserProfile, bool>> f)
        {
            //Expression<Func<DalUserProfile, bool>> -> Expression<Func<UserProfile, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUserProfile e)
        {
            var profile = e.ToOrmUserProfile();
            context.Set<UserProfile>().Add(profile);
        }

        public void Delete(DalUserProfile e)
        {
            var profile = e.ToOrmUserProfile();
            profile = context.Set<UserProfile>().Single(u => u.Id == profile.Id); // catch exception
            context.Set<UserProfile>().Remove(profile);
        }

        public void Update(DalUserProfile entity)
        {
            var profile = entity.ToOrmUserProfile();
            UserProfile oldProfile = context.Set<UserProfile>().Single(u => u.Id == profile.Id); // catch except and check that user in table
            context.Set<UserProfile>().AddOrUpdate(oldProfile, profile);
        }
    }
}
