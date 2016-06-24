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
    public class UserProfileRepository: IUserProfileRepository
    {
        private readonly DbContext context;

        public UserProfileRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUserProfile> GetAll()
        {
            return context.Set<UserProfile>().Select(p=>p).ToList().Select(pr => pr.ToDalUserProfile());
        }

        public DalUserProfile GetById(int key)
        {
            return context.Set<UserProfile>().FirstOrDefault(pr => pr.Id == key)?.ToDalUserProfile();
        }

        public DalUserProfile GetByPredicate(Expression<Func<DalUserProfile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUserProfile dalUserProfile)
        {
            context.Set<UserProfile>().Add(dalUserProfile.ToOrmUserProfile());
        }

        public void Delete(DalUserProfile dalProfile)
        {

            UserProfile profile = context.Set<UserProfile>().FirstOrDefault(pr => pr.Id == dalProfile.Id);
            if (profile != null)
                context.Set<UserProfile>().Remove(profile);
        }

        public void Update(DalUserProfile dalProfile)
        {
            UserProfile oldUserProfile = context.Set<UserProfile>().FirstOrDefault(pr => pr.Id == dalProfile.Id);
            if (oldUserProfile != null)
            {
                //oldUserProfile = dalProfile.ToOrmUserProfile();
                oldUserProfile.Id = dalProfile.Id;
                oldUserProfile.FirstName = dalProfile.FirstName;
                oldUserProfile.LastName = dalProfile.LastName;
                oldUserProfile.UserPhoto = dalProfile.UserPhoto;
                oldUserProfile.DateOfBirth = dalProfile.DateOfBirth;
                oldUserProfile.LastUpdateDate = dalProfile.LastUpdateDate;
            }
            else
                context.Set<UserProfile>().Add(dalProfile.ToOrmUserProfile());
        }
    }
}
