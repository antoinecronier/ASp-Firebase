namespace FirebaseClassLibrary.Entities
{
    public class EquipmentType : DbItem, ApiItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }
    }
}