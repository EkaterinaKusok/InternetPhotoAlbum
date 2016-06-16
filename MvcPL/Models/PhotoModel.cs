using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int TotalRating { get; set; }
        public DateTime CreationDate { get; set; }
        //public virtual ICollection<RatingModel> Ratings { get; set; }
        //public PhotoModel()
        //{
        //    Ratings = new List<RatingModel>();
        //}
    }
}