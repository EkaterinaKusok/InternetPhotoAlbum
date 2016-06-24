using System.Collections.Generic;

namespace MvcPL.Models.ViewModels
{
    public class PhotosViewModel
    {
        public UserModel ChosenUser { get; set; }
        public IEnumerable<PhotoModel> Photos { get; set; }
        public PhotoModel CurrentPhoto { get; set; }
        public IEnumerable<RatingModel> CurrentPhotoRatings { get; set; }
        public int? RatingOfCurrentUser { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}