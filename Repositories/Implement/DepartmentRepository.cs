using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NHNT.Constants;
using NHNT.Constants.Statuses;
using NHNT.Dtos;
using NHNT.EF;
using NHNT.Exceptions;
using NHNT.Models;

namespace NHNT.Repositories.Implement
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbContextConfig _context;

        public DepartmentRepository(DbContextConfig context)
        {
            _context = context;
        }

        public Department GetById(int id)
        {
            return _context.Departments
                .Include(d => d.User)
                .Include(d => d.Images)
                .Include(d => d.Group)
                .SingleOrDefault(d => d.Id == id);
        }

        public void Add(Department department)
        {
            if (department == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.DEPARTMENT_IS_NULL);
            }

            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            if (department == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.DEPARTMENT_IS_NULL);
            }

            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Department department = this.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public Department[] List(int page, int limit, string search, DepartmentDto dto)
        {
            if (page <= 0)
                page = 1;

            if (limit <= 0)
                limit = int.MaxValue;

            if (search == null) search = "";

            var skip = (page - 1) * limit;

            var query = _context.Departments.AsQueryable();

            if (dto.Status != null)
            {
                query = query.Where(d => d.Status.Equals(dto.Status) && d.Address.Contains(search));
            }
            else
            {
                query = query.Where(d => d.Address.Contains(search));
            }

            var departments = query
                .Include(d => d.User)
                .Include(d => d.Images)
                .Include(d => d.Group)
                .OrderByDescending(d => d.CreatedAt)
                .Skip(skip)
                .Take(limit);

            return departments.ToArray();
        }

        public Department[] FindByUserId(int userId)
        {
            var departments = _context.Departments.Where(department => department.UserId == userId).Include(d => d.Images).OrderByDescending(d => d.CreatedAt);
            return departments.ToArray();
        }

        public int Count()
        {
            return _context.Departments.Count();
        }
        public List<Department> Search(int pageIndex, int pageSize, DepartmentDto dto)
        {
            pageIndex = (pageIndex <= 0) ? 0 : pageIndex - 1;
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            int startIndex = pageIndex * pageSize;

            var query = _context.Departments.AsQueryable();

            if (dto.Status != null)
            {
                query = query.Where(q => q.Status.Equals(dto.Status));
            }

            if (dto.CreatedAt != null)
            {
                query = query.Where(q => q.CreatedAt.Equals(dto.CreatedAt));
            }

            if (dto.Status != null)
            {
                query = query.Where(q => q.Status.Equals(dto.Status));
            }

            return query
                .Include(q => q.User)
                .Include(q => q.Images)
                .Include(q => q.Group)
                .Skip(startIndex)
                .OrderBy(q => q.CreatedAt)
                .Take(pageSize)
                .ToList();
        }
    }
}