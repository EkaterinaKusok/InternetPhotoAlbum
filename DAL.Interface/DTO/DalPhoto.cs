namespace DAL.Interfacies.DTO
{
    public class DalPhoto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public int UserId { get; set; }
    }
}
