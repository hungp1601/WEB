using System;
using System.Collections.Generic;
using NHNT.Constants;

namespace NHNT.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Boolean IsDisabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}