using System;
using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; }
        public UserEntity()
        {
            Roles = new List<RoleEntity>();
        }
    }
}