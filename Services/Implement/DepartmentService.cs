using System;
using System.Collections.Generic;
using System.Linq;
using NHNT.Constants;
using NHNT.Constants.Statuses;
using NHNT.Dtos;
using NHNT.Exceptions;
using NHNT.Models;
using NHNT.Repositories;
using NHNT.Utils;
using System.Reflection;

namespace NHNT.Services.Implement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IImageService _imageService;

        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IImageService imageService
            )
        {
            this._departmentRepository = departmentRepository;
            _imageService = imageService;
        }


        public DepartmentDto[] List(int page, int limit, string search, DepartmentDto query)
        {
            var departments = _departmentRepository.List(page, limit, search, query);
            DepartmentDto[] result = Array.ConvertAll(array: departments, new Converter<Department, DepartmentDto>(ConvertDepartmentDto));
            // Console.WriteLine(JsonSerializer.Serialize(result));
            return result;
        }


        public static DepartmentDto ConvertDepartmentDto(Department department)
        {
            return new DepartmentDto(department);
        }

        public DepartmentDto[] FindByUserId(int userId)
        {
            var departments = _departmentRepository.FindByUserId(userId);

            DepartmentDto[] result = Array.ConvertAll(array: departments, new Converter<Department, DepartmentDto>(ConvertDepartmentDto));

            return result;
        }

        public int Count()
        {
            var count = _departmentRepository.Count();
            return count;
        }
        public Department GetById(int id)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            return department;
        }

        public void register(DepartmentRegisDto departmentDto)
        {

            DateTime currentTime = DateTimeUtils.GetCurrentTime(); ;

            var department = new Department
            {
                Address = departmentDto.Address,
                Price = departmentDto.Price,
                PhoneNumber = departmentDto.PhoneNumber,
                Acreage = departmentDto.Acreage,
                Status = DepartmentStatus.PENDING,
                Description = departmentDto.Description,
                IsAvailable = departmentDto.IsAvailable,
                CreatedAt = currentTime,
                UpdatedAt = currentTime,
                UserId = departmentDto.UserId,
                GroupId = departmentDto.GroupId,
            };
            _departmentRepository.Add(department);
            _imageService.saveMultiple(departmentDto.Images, department.Id);

            throw new System.NotImplementedException();
        }

        public void Update(int id, DepartmentUpdateDto departmentDto)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new InvalidOperationException("Department not found.");
            }
            Type dtoType = departmentDto.GetType();
            PropertyInfo[] dtoProperties = dtoType.GetProperties();

            foreach (PropertyInfo property in dtoProperties)
            {
                if (property.GetValue(departmentDto) != null)
                {
                    PropertyInfo departmentProperty = department.GetType().GetProperty(property.Name);
                    if (departmentProperty != null)
                    {
                        departmentProperty.SetValue(department, property.GetValue(departmentDto));
                    }
                }
            }
            _departmentRepository.Update(department);
            throw new NotImplementedException();
        }

        public List<DepartmentDto> Search(int pageIndex, int pageSize, DepartmentDto dto)
        {
            List<Department> departments = _departmentRepository.Search(pageIndex, pageSize, dto);
            return departments.Select(d => new DepartmentDto(d)).ToList();
        }

        public Department Confirm(int id, int status)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            DepartmentStatus enumStatus = DepartmentStatusHelper.Get(status);
            department.Status = enumStatus;

            _departmentRepository.Update(department);

            return department;
        }
    }
}