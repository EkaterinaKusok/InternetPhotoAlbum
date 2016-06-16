using System;
using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class UserProfileEntity
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] UserPhoto { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastUpdateDate { get; set; }
        //public virtual ICollection<PhotoEntity> Photos { get; set; }

        //public UserProfileEntity()
        //{
        //    Photos = new List<PhotoEntity>();
        //}
    }
}
