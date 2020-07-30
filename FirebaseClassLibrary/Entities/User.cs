using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Entities
{
    public class User : DbItem, ApiItem
    {
        public long? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual List<Role> Roles { get; set; } = new List<Role>();
        public virtual List<Car> Cars { get; set; } = new List<Car>();
    }
}
