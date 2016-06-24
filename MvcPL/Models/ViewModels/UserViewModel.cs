using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Ajax.Utilities;

namespace MvcPL.Models.ViewModels
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "User's e-mail")]
        public string Email { get; set; }
        
        [Display(Name = "User's roles in the system")]
        public IEnumerable<string> Roles { get; set; }

        [Required(ErrorMessage = "The field can not be empty.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field can not be empty.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "The field can not be empty.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime? DateOfBirth { get; set; }

        public byte[] UserPhoto { get; set; }

        [Display(Name = "Date of user's registration")]
        public DateTime CreationDate { get; set; }

        public UserViewModel() { }

        public UserViewModel(UserModel userModel, UserProfileModel userProfile, IEnumerable<string> userRoles)
        {
            if (userModel != null)
            {
                this.Id = userModel.Id;
                this.Email = userModel.Email;
                this.CreationDate = userModel.CreationDate;
            }
            this.Roles = userRoles;
            if (userProfile != null)
            {
                this.FirstName = userProfile.FirstName;
                this.LastName = userProfile.LastName;
                this.DateOfBirth = userProfile.DateOfBirth;
                this.UserPhoto = userProfile.UserPhoto;
            }
        }
    }
}