using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "The field can not be empty.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        [Display(Name = "Total rating")]
        public int TotalRating { get; set; }
        public DateTime CreationDate { get; set; }
        //public virtual ICollection<RatingModel> Ratings { get; set; }
        public PhotoModel()
        {
            User = new UserModel();
        }
    }
}