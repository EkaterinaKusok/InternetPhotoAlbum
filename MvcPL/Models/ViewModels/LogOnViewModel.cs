using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.ViewModels
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,30}$",
        ErrorMessage = "Nickname should be 2-30 characters (letters and numbers), the first symbol is letter.")]
        [Display(Name = "Nickname")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}