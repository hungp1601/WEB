using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NHNT.Models
{
    public class DepartmentGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}