using FirebaseClassLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Extensions
{
    public static class JsonExtensions
    {
        public static String ToJson(this ApiItem item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public static T ToOject<T>(this string item) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(item);
        }
    }
}
