using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Entities
{
    public class FirebaseResume : FirebaseItem
    {
        public DateTime CurrentTime { get; set; }
        public Dictionary<string, long> ControllersAccess { get; set; }
    }
}
