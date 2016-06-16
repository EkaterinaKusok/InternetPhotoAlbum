using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Providers
{
    //провайдер ролей указывает системе на статус пользователя и наделяет 
    //его определенные правами доступа
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));


        public override bool IsUserInRole(string email, string roleName)
        {
            var user = UserService.GetUserEntityByEmail(email).ToMvcUser();
            if (user == null)
                return false;
            IEnumerable<RoleModel> userRoles = RoleService.GetUserRoles(user.Id).Select(r=>r.ToMvcRole());
            if (userRoles == null)
                return false;
            if (userRoles.Any(role => role.RoleName == roleName))
            {
                return true;
            }
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = new string[] {};
            var user = UserService.GetUserEntityByEmail(username).ToMvcUser();

            if (user == null)
                return roles;
            var userRoles = RoleService.GetUserRoles(user.Id);
            if (userRoles == null)
                return roles;
            return userRoles.Select(role => role.Name).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleModel() { RoleName = roleName, Description = ""};
            RoleService.CreateRole(newRole.ToBllRole());
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}