using System;
using System.Collections.Generic;
using System.Linq;
using NHNT.Constants;
using NHNT.Models;

namespace NHNT.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<RoleDto> Roles { get; set; }

        public UserDto()
        {
            
        }

        public UserDto(User user)
        {
            if (user == null)
            {
                return;
            }
            
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            FullName = user.FullName;
            Phone = user.Phone;
            Gender = user.Gender;
            Birthday = user.Birthday;

            if (user.UserRoles != null && user.UserRoles.Any())
            {
                Roles = new List<RoleDto>();
                foreach (UserRole ur in user.UserRoles)
                {
                    Roles.Add(new RoleDto(ur.Role));
                }
            }
        }
    }
}