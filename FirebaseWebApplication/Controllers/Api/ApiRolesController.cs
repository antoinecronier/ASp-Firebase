using FirebaseClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FirebaseWebApplication.Controllers.Api
{
    [Route("api/roles/")]
    public class ApiRolesController : BaseApiController<Role>
    {
    }
}