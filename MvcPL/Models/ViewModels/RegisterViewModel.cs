using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.ViewModels
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,30}$",
        ErrorMessage = "Nickname should be 2-23 characters (letters and numbers), the first symbol is letter.")]
        [Display(Name = "Nickname")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Enter the code from the image")]
        public string Captcha { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        public string AvatarPath { get; set; }
    }
}