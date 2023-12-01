using System;
using System.ComponentModel.DataAnnotations;

namespace NHNT.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}