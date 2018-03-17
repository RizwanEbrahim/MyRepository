using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
   public class UserLogin
    {


        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class Logged
    {
        public List<UserLogin> UserList = new List<UserLogin>()
   {
        new UserLogin() { Username="user01",Password="pass1" },
        new UserLogin() {Username="user02",Password="pass2" }
    };
    }
}

