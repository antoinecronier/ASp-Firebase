using FirebaseClassLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirebaseWebApplication.Data
{
    public class WebApiDbContext : ApiDbContext
    {
        public WebApiDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}