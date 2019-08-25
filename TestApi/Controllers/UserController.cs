using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Common;
using TestApp.Business;
using TestApp.Business.Implementation;
using TestApp.Data;
using TestApp.Data.Models;

namespace TestApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserBusiness _userBusiness;
        Helper _commonRules = null;
        Dictionary<string, string> _httpResponse = null;
        public UserController()
        {
            this._userBusiness = new UserBusiness();
            _commonRules = new Helper();
            _httpResponse = new Dictionary<string, string>();
        }
        [Route("AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(Register regModel)
        {
            bool retVal = false;
            if (!ModelState.IsValid)
            {
                var getMessage = ModelState.Values.SelectMany(v => v.Errors.Select(d => d.ErrorMessage)).ToList()
                       .LastOrDefault();
                _httpResponse = _commonRules.SetResponse(bool.FalseString, "DC1000:Failed.");
                _httpResponse.Add(bool.FalseString, getMessage);

                return Ok(_httpResponse);
            }
            try
            {
                using (TestAppDbEntities context = new TestAppDbEntities())
                {
                    if (context.UserInfoes.Any(o => o.Email == regModel.Email))
                    {
                        _httpResponse = _commonRules.SetResponse(bool.FalseString, "DC2000:Email already in use.");
                        return Ok(_httpResponse);
                    }
                }
                retVal = _userBusiness.AddUser(regModel);
                if (retVal)
                {
                    _httpResponse = _commonRules.SetResponse(bool.TrueString, "DC1000:Success.");
                }
            }
            catch (Exception ex)
            {
            }
            return Ok(_httpResponse);
        }

        [Route("GetUser")]
        [HttpGet]
        public IHttpActionResult GetUserData(int id)
        {
            UsersList userData = null;
            try
            {
                userData = _userBusiness.GetUser(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            var jsonDictionary = JObject.Parse(JsonConvert.SerializeObject(userData));
            return Ok(jsonDictionary);
        }

        [Route("UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser(UpdateUser model)
        {
            bool _result = false;
            if (!ModelState.IsValid)
            {
                var getMessage = ModelState.Values.SelectMany(v => v.Errors.Select(d => d.ErrorMessage)).ToList()
                       .LastOrDefault();
                _httpResponse.Add(bool.FalseString, getMessage);

                return Ok(_httpResponse);
            }
            try
            {
                _result = _userBusiness.UpdateUser(model);
                if (_result)
                {
                    _httpResponse = _commonRules.SetResponse(bool.TrueString, "DC1000:Success.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(_httpResponse);

        }

        [Route("AddSkills")]
        [HttpPost]
        public IHttpActionResult AddUserSkills(UserData model)
        {
            bool _result = false;
            if (!ModelState.IsValid)
            {
                var getMessage = ModelState.Values.SelectMany(v => v.Errors.Select(d => d.ErrorMessage)).ToList()
                       .LastOrDefault();
                _httpResponse = _commonRules.SetResponse(bool.FalseString, "DC1000:Failed.");
                _httpResponse.Add(bool.FalseString, getMessage);

                return Ok(_httpResponse);
            }
            try
            {
                _result = _userBusiness.AddUserSkills(model);
                if (_result)
                {
                    _httpResponse = _commonRules.SetResponse(bool.TrueString, "DC1000:Success.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(_httpResponse);

        }

    }
}