using System.Collections.Generic;
using WebApiJWT;
using WebApiJWT.Models;

namespace WebApiJWT
{
    public partial class CoreFacade : ICoreFacade
    {
        public UserCO getUserCO()
        {
            if (this.controllersInstances.Contains("UserCO"))
                return (UserCO)this.controllersInstances["UserCO"];
            else
            {
                UserCO UserCo = new UserCO();
                this.controllersInstances.Add("UserCO", UserCo);
                return UserCo;
            }
        }

        public BusinessResult CreateUser(BOUser objUser)
        {
            return this.getUserCO().CreateUser(objUser);
        }

        public BusinessResult UpdateUser(BOUser objUser)
        {
            return this.getUserCO().UpdateUser(objUser);
        }

        public BusinessResult DeleteUser(int id)
        {
            return this.getUserCO().DeleteUser(id);
        }

        public BusinessResult GetUserById(int id)
        {
            return this.getUserCO().GetUserById(id);
        }

        public List<BOUser> GetAllUsers()
        {
            return this.getUserCO().GetAllUsers();
        }

        public BusinessResult UserLogin(BOUser objUser)
        {
            return this.getUserCO().UserLogin(objUser);
        }
    }
}
