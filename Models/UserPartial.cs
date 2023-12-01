using System.Collections.Generic;

namespace NHNT.Models
{
    public class UserPartial
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}