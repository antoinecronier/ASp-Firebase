namespace FirebaseClassLibrary.Entities
{
    public class Role : DbItem, ApiItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }
    }
}