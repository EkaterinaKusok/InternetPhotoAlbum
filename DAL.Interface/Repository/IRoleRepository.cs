using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        void AddUserToRole(int userId, string roleName);
        IEnumerable<DalRole> GetUserRoles(int userId);
        //IEnumerable<DalUser> GetUsersInRole(string roleName);
    }
}
