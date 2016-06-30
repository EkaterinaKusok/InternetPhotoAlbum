using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using BLL.Interfacies.Infrastructure;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.ViewModels;


namespace MvcPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IPhotoService photoService;
        private readonly IRatingService ratingService;
        private readonly IUserProfileService userProfileService;
        private readonly IRoleService roleService;

        public HomeController(IUserService userService, IPhotoService photoService, IRatingService ratingService,
            IUserProfileService userProfileService, IRoleService roleService)
        {
            this.userService = userService;
            this.photoService = photoService;
            this.ratingService = ratingService;
            this.userProfileService = userProfileService;
            this.roleService = roleService;
        }

        public ActionResult Index(string userName = null)
        {
            UserModel currentUser = userService.GetUserEntityByEmail(User.Identity.Name).ToMvcUser();
            UserModel user = null;
            if (userName != null)
            {
                try
                {
                    user = userService.GetUserEntityByEmail(userName)?.ToMvcUser();
                }
                catch (ValidationException ex)
                {
                }
            }
            if (user == null)
                user = currentUser;
            UserProfileModel profile = userProfileService.GetUserProfileEntityById(user.Id)?.ToMvcUserProfile();
            if (profile == null)
                RedirectToAction("NotFound", "Error");
            IEnumerable<string> roles = roleService.GetUserRoles(user.Id)?.Select(r => r.ToMvcRole().RoleName);
           
            var photosModel = GetCurrentPhotosModel(user, 1);
            UserViewModel userView = new UserViewModel(user, profile, photosModel, roles);
            
            return View(userView);
        }

        [HttpPost]
        public ActionResult LinksView(int userId, int page, string pageName = null)
        {
            UserModel user = null;
            try
            {
                user = userService.GetUserEntityById(userId)?.ToMvcUser();
            }
            catch (ValidationException ex)
            {
                user = userService.GetUserEntityByEmail(User.Identity.Name).ToMvcUser();
            }
            var photosModel = GetCurrentPhotosModel(user, page);
            
            return PartialView("_PhotoWithLinks", photosModel);
        }

        [HttpGet]
        public ActionResult UserSettings()
        {
            UserModel user = new UserModel();
            try
            {
                user = userService.GetUserEntityByEmail(User.Identity.Name)?.ToMvcUser();
            }
            catch (ValidationException ex)
            {
                return RedirectToAction("Index");
            }
            UserProfileModel profile = userProfileService.GetUserProfileEntityById(user.Id)?.ToMvcUserProfile();
            UserViewModel userViewModel = new UserViewModel(user, profile, null, null);
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult UserSettings(UserViewModel viewModel, HttpPostedFileBase uploadImage, string removePhoto)
        {
            UserModel user = userService.GetUserEntityByEmail(User.Identity.Name)?.ToMvcUser();
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            UserProfileModel profile = userProfileService.GetUserProfileEntityById(user.Id)?.ToMvcUserProfile();

            if (ModelState.IsValid)
            {
                profile.FirstName = viewModel.Profile.FirstName;
                profile.LastName = viewModel.Profile.LastName;
                profile.DateOfBirth = viewModel.Profile.DateOfBirth;

                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    profile.UserPhoto = imageData;
                }

                if (removePhoto != null)
                {
                    profile.UserPhoto = null;
                }
                userService.UpdateUser(user.ToBllUser());
                userProfileService.UpdateUserProfile(profile.ToBllUserProfile());

                return RedirectToAction("Index");
            }
            return View(new UserViewModel(user, profile, null, null));
        }
        
        private PhotosViewModel GetCurrentPhotosModel(UserModel user, int page)
        {
            int pageSize = 8;
            var photos = photoService.GetUserPhotos(user.Id).Select(ph => ph.ToMvcPhoto())
                .OrderByDescending(ph => ph.CreationDate);
            int totalItems = photos.Count();
            var resultPhotos = photos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            foreach (var photo in resultPhotos)
            {
                //photo.User = new UserModel();
                photo.User.Email = user.Email;
            }
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems
            };

            return new PhotosViewModel
            {
                ChosenUser = user,
                Photos = resultPhotos,
                PageInfo = pageInfo
            };
        }
    }
}
