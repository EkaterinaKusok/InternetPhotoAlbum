using System;
using System.Collections.Generic;

namespace DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }       
        //public virtual ICollection<DalRole> Roles { get; set; }
        //public DalUser()
        //{
        //    Roles = new List<DalRole>();
        //}
    }
}
