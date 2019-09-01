using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data.Models;

namespace TestApp.Data.Implementaion
{
    public class UserRepository : IUserRepository
    {
        public bool AddUser(Register userModel)
        {
            try
            {
                using (TestAppDbEntities context = new TestAppDbEntities())
                {
                    UserInfo objUser = new UserInfo()
                    {
                        Name = userModel.Name,
                        Email = userModel.Email,
                        Password = userModel.Password, 
                        DOB = userModel.DOB,
                        Location = userModel.Location,
                        UsrType = userModel.UsrType
                    };
                    context.UserInfoes.Add(objUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public UsersList GetUser(int id)
        {

            UsersList _result = null;
            List<UserSkill> skill = new List<UserSkill>();
            UserInfo data = null;
            List<UserData> skillList = null;
            try
            {
                using (TestAppDbEntities context = new TestAppDbEntities())
                {
                    var query = from st in context.UserInfoes where st.UserId == id select st;
                    data = query.FirstOrDefault<UserInfo>();

                    skillList = context.UserDatas.Where(a => a.UserId == id).ToList();
                }
                _result = new UsersList()
                {
                    Name = data.Name,
                    Email = data.Email, 
                    DOB = data.DOB,
                    Location = data.Location,
                };

                UserSkill us = null;
                foreach (var x in skillList)
                {
                    us = new UserSkill();
                    us.UserId = x.UserId;
                    us.Skill = x.Skill;
                    us.Experience = x.Experience;
                    us.Certification = x.Certification;
                    us.id = x.id;

                    skill.Add(us);
                    us = null;
                }
                if (skill.Count > 0) { _result.userSkills=skill; }

            }
            catch (Exception Ex)
            {
                throw;
            }
            return _result;
        }

        public bool UpdateUser(UpdateUser viewModel)
        {
            using (TestAppDbEntities context = new TestAppDbEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        UserInfo _userInfo = new UserInfo();
                        _userInfo = context.UserInfoes.First(a => a.UserId == viewModel.UserId);
                        _userInfo.Email = viewModel.Email;
                        _userInfo.Name = viewModel.Name; 
                        _userInfo.DOB = viewModel.DOB;
                        _userInfo.Location = viewModel.Location;

                        context.SaveChanges();
                        UserData _userData;
                        foreach (var item in viewModel.userSkills)
                        {
                            _userData = context.UserDatas.First(a => a.id == item.id);

                            _userData.Skill = item.Skill;
                            _userData.Experience = item.Experience;
                            _userData.Certification = item.Certification; 
                             
                            context.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return true;
        }

        public bool AddUserSkills(UserData userModel)
        {
            try
            {
                using (TestAppDbEntities context = new TestAppDbEntities())
                {
                    UserData objUser = new UserData()
                    {
                        Skill = userModel.Skill,
                        Experience = userModel.Experience,
                        Certification = userModel.Certification,
                        UserId = userModel.UserId
                    };
                    context.UserDatas.Add(objUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
