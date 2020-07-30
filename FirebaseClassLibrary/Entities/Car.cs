namespace FirebaseClassLibrary.Entities
{
    public class Car : DbItem, ApiItem
    {
        public long? Id { get; set; }
        public virtual CarType Type { get; set; }
        public string Registration { get; set; }
        public double? Mileage { get; set; }
    }
}