using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserProfileModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "User's roles in the system")]
        public IEnumerable<string> Roles { get; set; }

        [Required(ErrorMessage = "The field can not be empty.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field can not be empty.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public byte[] UserPhoto { get; set; }

        //[Required(ErrorMessage = "The field can not be empty.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime? DateOfBirth { get; set; }

        public DateTime LastUpdateDate { get; set; }
        //public virtual ICollection<PhotoModel> Photos { get; set; }

        public UserProfileModel()
        {
            Roles = new List<string>();
        }
    }
}