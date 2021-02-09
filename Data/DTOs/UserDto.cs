using apshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.DTOs
{
    public class UserDto
    {
        private string name;

        public UserDto(string username, string password, string name)
        {
            this.username = username;
            this.password = password;
            this.name = name;
        }

        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }

}
