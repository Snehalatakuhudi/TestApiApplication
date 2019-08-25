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
    public class ProfileController : ApiController
    {
        private readonly IProfileBusiness _profileBusiness;
        Helper _commonRules = null;
        Dictionary<string, string> _httpResponse = null;
        public ProfileController()
        {
            this._profileBusiness = new ProfileBusiness();
            _commonRules = new Helper();
            _httpResponse = new Dictionary<string, string>();
        } 

        [Route("api/Profile/Login")]
        [HttpPost]

        public IHttpActionResult Login(Login loginModel)
        {

            if (!ModelState.IsValid)
            {
                var getMessage = ModelState.Values.SelectMany(v => v.Errors.Select(d => d.ErrorMessage)).ToList()
                       .LastOrDefault();
                _httpResponse.Add(bool.FalseString, getMessage);

                return Ok(_httpResponse);
            }

            UserInfo result = _profileBusiness.Login(loginModel);

            if (result == null)
            {
                return Ok(_commonRules.SetResponse(bool.FalseString, "DC1000:Invalid Credentials."));
            }
            else
            {
                return Ok(JObject.Parse(JsonConvert.SerializeObject(result)));
            }
        }
       
    }
}