using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NHNT.Constants;
using NHNT.Models;

namespace NHNT.Dtos
{
    public class DepartmentUpdateDto
    {
        public string? Address { get; set; }

        public Decimal? Price { get; set; }

        public string? PhoneNumber { get; set; }

        public Decimal? Acreage { get; set; }

        public DepartmentStatus? Status { get; set; }

        public string? Description { get; set; }

        public bool? IsAvailable { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<IFormFile> Images { get; set; }

        public DepartmentUpdateDto(Department department)
        {
            if (department == null)
            {
                return;
            }

            this.Address = department.Address;
            this.Price = department.Price;
            this.PhoneNumber = department.PhoneNumber;
            this.Acreage = department.Acreage;
            this.Status = department.Status;
            this.Description = department.Description;
            this.IsAvailable = department.IsAvailable ?? false;
            this.CreatedAt = department.CreatedAt;
            this.UpdatedAt = department.UpdatedAt;
        }

        public DepartmentUpdateDto() { }

    }


}