using System;

namespace BLL.Interfacies.Entities
{
    public class PhotoEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRating { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        //public virtual ICollection<RatingEntity> Ratings { get; set; }
        //public PhotoEntity()
        //{
        //    Ratings = new List<RatingEntity>();
        //}
    }
}
