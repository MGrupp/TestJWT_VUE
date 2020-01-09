using System.Net;
using System.Threading;
using System.Web.Http;
using WebApiJWT.Models;

namespace WebApiJWT.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(BOUser login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            BusinessResult result = CoreFactory.Instance.UserLogin(login);

            if (result.Success)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Email);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}