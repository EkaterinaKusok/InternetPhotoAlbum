using System.Collections.Generic;

namespace DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual DalRole Role { get; set; }
        //public virtual ICollection<DalRole> Roles { get; set; }
        public virtual ICollection<DalPhoto> Photos { get; set; }

        public DalUser()
        {
            //Roles = new List<DalRole>();
            Photos = new List<DalPhoto>();
        }
    }
}
