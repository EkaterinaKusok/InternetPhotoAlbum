using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Ajax.Utilities;

namespace MvcPL.Models.ViewModels
{
    public class UserViewModel
    {

        public UserModel User { get; set; }
        public UserProfileModel Profile { get; set; }
        public PhotosViewModel Photos { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public UserViewModel()
        {
            User = new UserModel();
            Profile = new UserProfileModel();
            Photos = new PhotosViewModel();
            Roles = new List<string>();
        }

        public UserViewModel(UserModel userModel, UserProfileModel userProfile, PhotosViewModel photos, IEnumerable<string> userRoles)
        {
            User = new UserModel();
            Profile = new UserProfileModel();
            Photos = new PhotosViewModel();
            Roles = new List<string>();
            if (userModel!= null)
            {
                this.User.Id = userModel.Id;
                this.User.Email = userModel.Email;
                this.User.CreationDate = userModel.CreationDate;
            }
            
            if (userProfile != null)
            {
                this.Profile.FirstName = userProfile.FirstName;
                this.Profile.LastName = userProfile.LastName;
                this.Profile.DateOfBirth = userProfile.DateOfBirth;
                this.Profile.UserPhoto = userProfile.UserPhoto;
                this.Profile.Roles = userRoles;
            }
            this.Photos = photos;
            this.Roles = userRoles;
        }
    }
}