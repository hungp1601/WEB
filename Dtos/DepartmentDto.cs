using System;
using System.Collections.Generic;
using System.Linq;
using NHNT.Constants;
using NHNT.Models;

namespace NHNT.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public Decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public Decimal Acreage { get; set; }
        public DepartmentStatus? Status { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserDto User { get; set; }
        public DepartmentGroupDto Group { get; set; }
        public ICollection<ImageDto> Images { get; set; }


        public DepartmentDto(int id, string address)
        {
            this.Id = id;
            this.Address = address;

        }
        public DepartmentDto()
        {

        }

        public DepartmentDto(DepartmentStatus status)
        {
            this.Status = status;
        }

        public DepartmentDto(Department department)
        {
            if (department == null)
            {
                return;
            }


            this.Id = department.Id;
            this.Address = department.Address;
            this.Price = department.Price;
            this.PhoneNumber = department.PhoneNumber;
            this.Acreage = department.Acreage;
            this.Status = department.Status;
            this.Description = department.Description;
            this.IsAvailable = department.IsAvailable ?? false;
            this.CreatedAt = department.CreatedAt;
            this.UpdatedAt = department.UpdatedAt;

            if (department.User != null)
            {
                this.User = new UserDto(user: department.User);
            }

            if (department.Group != null)
            {
                this.Group = new DepartmentGroupDto(department.Group);
            }

            if (department.Images != null && department.Images.Any())
            {
                this.Images = new List<ImageDto>();
                foreach (Image image in department.Images)
                {
                    Images.Add(new ImageDto(image));
                }
            }
        }
    }
}