using System.Collections.Generic;

namespace DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual ICollection<DalRole> Roles { get; set; }

        public DalUser()
        {
            Roles = new List<DalRole>();
        }
    }
}
