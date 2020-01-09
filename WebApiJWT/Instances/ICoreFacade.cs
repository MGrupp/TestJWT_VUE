using System.Collections.Generic;
using WebApiJWT.Models;

namespace WebApiJWT
{
    public interface ICoreFacade
    {
        #region USER

        BusinessResult CreateUser(BOUser objUser);

        BusinessResult UpdateUser(BOUser objUser);

        BusinessResult DeleteUser(int id);

        BusinessResult GetUserById(int id);

        List<BOUser> GetAllUsers();

        BusinessResult UserLogin(BOUser objUser);

        #endregion
    }
}
