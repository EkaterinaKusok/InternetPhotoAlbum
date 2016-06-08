using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRepository : IRepository<DalUser>//Add user repository methods!
    {
        //ICollection<DalRole> Roles { get; set; }
        //ICollection<DalPhoto> Photos { get; set; }
        DalRole GetRole(int key);
        ICollection<DalPhoto> GetPhotosByUserId(int key);
    }
}