using System.Collections.Generic;

namespace MvcPL.Models.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}