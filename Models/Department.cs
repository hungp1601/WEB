using System;
using System.Collections.Generic;
using NHNT.Constants;
using System.ComponentModel.DataAnnotations;

namespace NHNT.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public Decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public Decimal Acreage { get; set; } // Diện tích phòng trọ
        public DepartmentStatus Status { get; set; }
        public string Description { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? GroupId { get; set; }
        public DepartmentGroup Group { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}