using System.Collections.Generic;
using NHNT.Dtos;
using NHNT.Models;

namespace NHNT.Services
{
    public interface IDepartmentService
    {
        DepartmentDto[] List(int page, int limit, string search, DepartmentDto query);
        DepartmentDto[] FindByUserId(int userId);
        int Count();
        Department GetById(int id);

        void register(DepartmentRegisDto departmentDto);

        void Update(int id, DepartmentUpdateDto departmentDto);
        List<DepartmentDto> Search(int pageIndex, int pageSize, DepartmentDto dto);
        Department Confirm(int id, int status);
    }
}