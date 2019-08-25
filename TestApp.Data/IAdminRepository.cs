using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data.Models;

namespace TestApp.Data
{
    public interface IAdminRepository
    { 
        List<UsersList> GetUsersList();
        bool DeleteUser(int id);
    }
}
