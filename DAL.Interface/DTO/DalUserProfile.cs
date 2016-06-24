using System;
using System.Collections.Generic;

namespace DAL.Interfacies.DTO
{
    public class DalUserProfile :IEntity
    {
        public int Id { get; set; } //=UserId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] UserPhoto { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime LastUpdateDate { get; set; }
        //public virtual ICollection<DalPhoto> Photos { get; set; }

        //public DalUserProfile()
        //{
        //    Photos = new List<DalPhoto>();
        //}
    }
}
