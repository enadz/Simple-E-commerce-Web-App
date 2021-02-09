using System.Collections.Generic;

namespace apshop.Data.Models
{
    public class Role
    {
        public int roleId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public virtual ICollection<User> users{ get; set; }
        public Role(int userId, string name) { this.userId = userId; this.name = name; }
    }
}