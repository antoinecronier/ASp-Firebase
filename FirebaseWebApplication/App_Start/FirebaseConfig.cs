using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirebaseWebApplication.App_Start
{
    public class FirebaseConfig
    {
        internal static void Load()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("/Users/tact/source/repos/ASP-Firebase/FirebaseWebApplication/Keys/ASP-firebasekey.json"),
            });
        }
    }
}