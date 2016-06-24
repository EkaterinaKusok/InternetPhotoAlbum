using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Infrastructure;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public UserEntity GetUserEntityById(int id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
                throw new ValidationException("User with the given ID isn't found.", "");
            return user.ToBllUser();
        }

        public UserEntity GetUserEntityByEmail(string email)
        {
            var user = userRepository.GetUserByEmail(email);
            if (user == null)
                throw new ValidationException("User with the given e-mail isn't found.", "");
            return user.ToBllUser();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }
    }
}
