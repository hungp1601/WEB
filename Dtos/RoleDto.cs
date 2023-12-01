using NHNT.Models;

namespace NHNT.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RoleDto(Role role)
        {
            Id = role.Id;
            Name = role.Name;
            Description = role.Description;
        }
    }
}