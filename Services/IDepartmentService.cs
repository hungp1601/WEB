using System.Collections.Generic;
using System;
using NHNT.Dtos;
using NHNT.Models;

namespace NHNT.Services
{
    public interface IDepartmentService
    {
        DepartmentDto[] List(int page, int limit, string search, DepartmentDto query, DateTime start_date, DateTime end_date);
        DepartmentDto[] FindByUserId(int userId);
        int Count();
        Department GetById(int id);

        void register(DepartmentRegisDto departmentDto);

        void Update(int id, DepartmentUpdateDto departmentDto);
        List<DepartmentDto> Search(int pageIndex, int pageSize, DepartmentDto dto, DateTime start_date, DateTime end_date);
        Department Confirm(int id, int status);
    }
}