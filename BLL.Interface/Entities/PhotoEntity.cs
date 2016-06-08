namespace BLL.Interfacies.Entities
{
    public class PhotoEntity
    {
        public int Id { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public int UserId { get; set; }
    }
}
