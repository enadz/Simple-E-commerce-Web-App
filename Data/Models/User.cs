using System.Collections.Generic;

namespace apshop.Data.Models
{
    public class User
    {
        public int userId { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public Role role { get; set; }


        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            role = new Role(userId, "Customer");
        }

      
      
        //public virtual ICollection<Role> role{ get; set; }
        public virtual ICollection<Order> order { get; set; }
       
    }
}