using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Infrastructure;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.ViewModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;
        private readonly IRoleService roleService;

        public UserController(IUserService userService, IUserProfileService userProfileService, IRoleService roleService)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
            this.roleService = roleService;
        }

        public ActionResult UsersEdit()
        {
            IEnumerable<UserModel> allUserModels = userService.GetAllUserEntities().Select(u => u.ToMvcUser());
            List<UserViewModel> resultUsers = new List<UserViewModel>();
            foreach (var userModel in allUserModels)
            {
                var currentRoleNames = roleService.GetUserRoles(userModel.Id).Select(role => role.Name);

                UserProfileModel userProfile =
                    userProfileService.GetUserProfileEntityById(userModel.Id).ToMvcUserProfile();
                UserViewModel user = new UserViewModel()
                {
                    User = userModel,
                    Profile = userProfile,
                    Photos = null,
                    Roles = currentRoleNames
                };
                if (userProfile != null)
                {
                    user.Profile.FirstName = userProfile.FirstName;
                    user.Profile.LastName = userProfile.LastName;
                    user.Profile.DateOfBirth = userProfile.DateOfBirth;
                    user.Profile.UserPhoto = userProfile.UserPhoto;
                }
                resultUsers.Add(user);

            }
            return View(resultUsers);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult EditUser(string userName = null)
        {
            if (userName==null)
            {
                return RedirectToAction("UsersEdit");
            }
            UserModel userModel;
            try
            {
                userModel = userService.GetUserEntityByEmail(userName).ToMvcUser();
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("NotFound", "Error");
            }
            UserProfileModel profile =
                        userProfileService.GetUserProfileEntityById(userModel.Id).ToMvcUserProfile();
            UserViewModel user = new UserViewModel(userModel, profile, null, null);
            return View(user);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EditUser(UserViewModel viewModel)
        {
            UserModel userModel;
            try
            {
                userModel = userService.GetUserEntityByEmail(viewModel.User.Email).ToMvcUser();
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("UsersEdit");
            }
            UserProfileModel profile = userProfileService.GetUserProfileEntityById(userModel.Id).ToMvcUserProfile();
            if (ModelState.IsValid)
            {
                //userModel.Email=...;
                profile.Id = userModel.Id;
                profile.FirstName = viewModel.Profile.FirstName;
                profile.LastName = viewModel.Profile.LastName;
                profile.DateOfBirth = viewModel.Profile.DateOfBirth;
                profile.LastUpdateDate = DateTime.Now;
                //userService.UpdateUser(userModel.ToBllUser());
                userProfileService.UpdateUserProfile(profile.ToBllUserProfile());
                return RedirectToAction("UsersEdit");
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult DeleteUser(string userName = null)
        { 
            UserModel user = new UserModel();
            try
            {
                user = userService.GetUserEntityByEmail(userName)?.ToMvcUser();
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("UsersEdit");
                //return HttpNotFound();
            }
            return View(user);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(UserViewModel viewModel)
        {
            UserModel user = new UserModel()
            {
                Id = viewModel.User.Id,
                Email = viewModel.User.Email
            };
            userService.DeleteUser(user.ToBllUser());
            return RedirectToAction("UsersEdit");
        }
    }
}