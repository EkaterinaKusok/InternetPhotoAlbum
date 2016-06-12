using System.Collections.Generic;

namespace DAL.Interfacies.DTO
{
    public class DalPhoto : IEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<DalRating> Ratings { get; set; }
        public DalPhoto()
        {
            Ratings = new List<DalRating>();
        }
    }
}
