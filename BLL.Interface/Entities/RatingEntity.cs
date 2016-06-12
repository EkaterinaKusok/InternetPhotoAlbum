namespace BLL.Interfacies.Entities
{
    public class RatingEntity
    {
        public int Id { get; set; }
        public int UserRating { get; set; }
        public int FromUserId { get; set; }
        public int PhotoId { get; set; }
    }
}
