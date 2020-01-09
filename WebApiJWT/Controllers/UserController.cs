using System.Collections.Generic;
using System.Web.Http;
using WebApiJWT.Models;

namespace WebApiJWT.Controllers
{
    //[Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpGet]
        public List<BOUser> GetAll()
        {
            return CoreFactory.Instance.GetAllUsers();
        }

        [HttpPost]
        [Route("create")]
        public BusinessResult Create([FromBody] BOUser objUser)
        {
            return CoreFactory.Instance.CreateUser(objUser);
        }

        [HttpPost]
        [Route("update")]
        public BusinessResult Update([FromBody] BOUser objUser)
        {
            return CoreFactory.Instance.UpdateUser(objUser);
        }

        [HttpDelete]
        public BusinessResult Delete([FromBody] BOUser objUser)
        {
            return CoreFactory.Instance.DeleteUser(objUser.Id);
        }

    }
}