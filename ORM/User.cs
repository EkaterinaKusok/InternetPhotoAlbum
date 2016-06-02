namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User  
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
            Photos = new List<Photo>();
        }
    }
}

