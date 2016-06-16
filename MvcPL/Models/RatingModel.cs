using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class RatingModel
    {
        public int Id { get; set; }
        public int UserRating { get; set; }
        public int? FromUserId { get; set; }
        public int PhotoId { get; set; }
    }
}