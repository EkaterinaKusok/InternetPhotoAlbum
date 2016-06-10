using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Role")]
        public string UserRoleName { get; set; }
        public RoleModel UserRole { get; set; }
        public virtual ICollection<PhotoModel> UserPhotos { get; set; }

        public UserViewModel()
        {
            UserPhotos = new List<PhotoModel>();
        }
    }
}