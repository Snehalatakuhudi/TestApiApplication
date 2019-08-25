using System.Collections.Generic;
using TestApp.Data.Models;

namespace TestApp.Business
{
    public interface IAdminBusiness
    {
        List<UsersList> GetUsersList();
        bool DeleteUser(int id);
    }
}
