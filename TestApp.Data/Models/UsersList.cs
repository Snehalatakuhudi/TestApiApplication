using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Data.Models
{
   public class UsersList
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public DateTime? DOB { get; set; }
        public string Location { get; set; }
        public List<UserSkill> userSkills { get; set; }
    } 
}
