using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int UserRating { get; set; }

        public int? UserProfileId { get; set; } //from who this rating
        public virtual UserProfile UserProfile{ get; set; }

        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
