using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class UserModel
    {
        [ScaffoldColumn(false)]
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "User's e-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string Password { get; set; }

        [Display(Name = "Date of user's registration")]
        public DateTime CreationDate { get; set; }
        //public virtual ICollection<RoleModel> Roles { get; set; }
        //public UserModel()
        //{
        //    Roles = new List<RoleModel>();
        //}
    }
}