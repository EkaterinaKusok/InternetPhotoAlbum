using System.Collections.Generic;

namespace MvcPL.Models.ViewModels
{
    public class PhotosViewModel
    {
        public UserModel ChosenUser { get; set; }
        public string SearchTag { get; set; }
        public IEnumerable<PhotoModel> Photos { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}