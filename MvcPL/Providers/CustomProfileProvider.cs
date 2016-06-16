using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Profile;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Providers
{
    public class CustomProfileProvider : ProfileProvider
    {
        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        public IUserProfileService ProfileService
            => (IUserProfileService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserProfileService));

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            // коллекция, которая возвращает значения свойств профиля
            var result = new SettingsPropertyValueCollection();

            if (collection == null || collection.Count < 1 || context == null)
            {
                return result;
            }

            // получаем из контекста имя пользователя - логин в системе
            var username = (string)context["UserName"];
            if (String.IsNullOrEmpty(username)) return result;

            // получаем id пользователя из таблицы Users по логину
            var firstOrDefault = UserService.GetUserEntityByEmail(username).ToMvcUser();
            if (firstOrDefault != null)
            {
                int userId = firstOrDefault.Id;
                // по этому id извлекаем профиль из таблицы профилей
                UserProfileModel profile = ProfileService.GetUserProfileEntityById(userId).ToMvcUserProfile();
                if (profile != null)
                {
                    foreach (SettingsProperty prop in collection)
                    {
                        var spv = new SettingsPropertyValue(prop)
                        {
                            PropertyValue = profile.GetType().GetProperty(prop.Name).GetValue(profile, null)
                        };
                        result.Add(spv);
                    }
                }
                else
                {
                    foreach (SettingsProperty prop in collection)
                    {
                        var svp = new SettingsPropertyValue(prop) { PropertyValue = null };
                        result.Add(svp);
                    }
                }
            }
            return result;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            // получаем логин пользователя
            var username = (string)context["UserName"];

            if (string.IsNullOrEmpty(username) || collection.Count < 1)
                return;

            // получаем id пользователя из таблицы Users по логину
            var firstOrDefault = UserService.GetUserEntityByEmail(username).ToMvcUser();
            if (firstOrDefault != null)
            {
                int userId = firstOrDefault.Id;
                // по этому id извлекаем профиль из таблицы профилей
                UserProfileModel profile = ProfileService.GetUserProfileEntityById(userId).ToMvcUserProfile();
                // если такой профиль уже есть изменяем его
                if (profile != null)
                {
                    foreach (SettingsPropertyValue val in collection)
                    {
                        profile.GetType().GetProperty(val.Property.Name).SetValue(profile, val.PropertyValue);
                    }
                    profile.LastUpdateDate = DateTime.Now;
                    ProfileService.UpdateUserProfile(profile.ToBllUserProfile());
                }
                else
                {
                    // если нет, то создаем новый профиль и добавляем его
                    profile = new UserProfileModel();
                    foreach (SettingsPropertyValue val in collection)
                    {
                        profile.GetType().GetProperty(val.Property.Name).SetValue(profile, val.PropertyValue);
                    }
                    profile.LastUpdateDate = DateTime.Now;
                    profile.Id = userId;
                    ProfileService.CreateUserProfile(profile.ToBllUserProfile());
                }
            }
        }

        public override string ApplicationName { get; set; }
        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
            int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption,
            string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }
}