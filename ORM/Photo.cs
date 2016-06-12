namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public Photo()
        {
            Ratings = new List<Rating>();
        }
    }
}
