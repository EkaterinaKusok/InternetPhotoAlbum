namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; } //It's User Id
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] UserPhoto { get; set; }
        //public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

        public UserProfile()
        {
            Photos = new List<Photo>();
            Ratings = new List<Rating>();
        }
    }
}
