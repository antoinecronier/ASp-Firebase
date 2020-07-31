using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Configurations
{
    public class FirebaseConfiguration
    {
        public static void Load()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("/Users/tact/source/repos/ASP-Firebase/FirebaseClassLibrary/Keys/ASP-firebasekey.json"),
            });
        }
    }
}
