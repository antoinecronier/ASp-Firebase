using System.Collections.Generic;

namespace FirebaseClassLibrary.Entities
{
    public class CarType : DbItem, ApiItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public virtual List<EquipmentType> EquipmentTypes { get; set; }
    }
}