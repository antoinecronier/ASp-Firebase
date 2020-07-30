using System.Web.Http;
using FirebaseClassLibrary.Entities;

namespace FirebaseWebApplication.Controllers.Api
{
    [Route("api/users/")]
    public class ApiUsersController : BaseApiController<User>
    {
    }
}