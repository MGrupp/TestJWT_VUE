using System.Web;
using System.Web.Http;

namespace WebApiJWT
{
    public class Global : HttpApplication
    {
        void Application_Start()
        {
            // Código que se ejecuta al iniciar la aplicación
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}