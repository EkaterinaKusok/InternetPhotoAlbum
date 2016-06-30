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

        
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,30}$",
        ErrorMessage = "Nickname should be 2-30 characters (letters and numbers), the first symbol is letter.")]
        [Display(Name = "Nickname")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string Password { get; set; }

        [Display(Name = "Date of user's registration")]
        public DateTime CreationDate { get; set; }
    }
}