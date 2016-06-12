namespace DAL.Interfacies.DTO
{
    public class DalRating :IEntity
    {
        public int Id { get; set; }
        public int UserRating { get; set; }
        public int FromUserId { get; set; } 
        public int PhotoId { get; set; }
    }
}
