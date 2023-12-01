using NHNT.Models;

namespace NHNT.Dtos
{
    public class DepartmentGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DepartmentGroupDto(DepartmentGroup group)
        {
            if (group == null)
            {
                return;
            }

            this.Id = group.Id;
            this.Name = group.Name;
            this.Description = group.Description;
        }
    }
}