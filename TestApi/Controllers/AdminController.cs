using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestApp.Business;
using TestApp.Data.Models;
using TestApp.Business.Implementation;
using TestApp.Data;
using TestApi.Common;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestApi.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IAdminBusiness _adminBusiness;
        Helper _commonRules = null;
        Dictionary<string, string> _httpResponse = null;
        public AdminController()
        {
            this._adminBusiness = new AdminBusiness();
            _commonRules = new Helper();
            _httpResponse = new Dictionary<string, string>();
        } 

        [Route("api/Admin/Get")]
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IEnumerable<List<UsersList>> Get()
        {
           List<UsersList> result=new List<UsersList>();

            result = _adminBusiness.GetUsersList();

            yield return result;
        }
         
        [Route("api/Admin/DeleteUser")]
        [HttpGet]
        public string DeleteUser(int id)
        {
            bool result = false;
            result = _adminBusiness.DeleteUser(id);

            return "";
        }
    }
}