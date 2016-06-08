using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleId { get; set; }
        //public virtual ICollection<RoleEntity> Roles { get; set; }
        public virtual ICollection<PhotoEntity> Photos { get; set; }

        public UserEntity()
        {
            //Roles = new List<RoleEntity>();
            Photos = new List<PhotoEntity>();
        }
    }
}