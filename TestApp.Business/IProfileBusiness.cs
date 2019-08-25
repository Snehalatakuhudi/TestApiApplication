using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;
using TestApp.Data.Models;

namespace TestApp.Business
{
    public interface IProfileBusiness
    {
        UserInfo Login(Login loginModel);   
    }
}
