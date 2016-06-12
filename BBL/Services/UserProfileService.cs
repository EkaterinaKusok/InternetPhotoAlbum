using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class UserProfileService: IUserProfileService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalUserProfile> profileRepository;

        public UserProfileService(IUnitOfWork uow, IRepository<DalUserProfile> repository)
        {
            this.uow = uow;
            this.profileRepository = repository;
        }

        public UserProfileEntity GetUserProfileEntityById(int id)
        {
            return profileRepository.GetById(id).ToBllUserProfile();
        }

        public IEnumerable<UserProfileEntity> GetAllUserProfileEntities()
        {
            return profileRepository.GetAll().Select(pr => pr.ToBllUserProfile());
        }

        public void CreateUserProfile(UserProfileEntity profile)
        {
            profileRepository.Create(profile.ToDalUserProfile());
            uow.Commit();
        }

        public void DeleteUserProfile(UserProfileEntity profile)
        {
            profileRepository.Delete(profile.ToDalUserProfile());
            uow.Commit();
        }

        public void UpdateUserProfile(UserProfileEntity profile)
        {
            profileRepository.Update(profile.ToDalUserProfile());
            uow.Commit();
        }
    }
}
