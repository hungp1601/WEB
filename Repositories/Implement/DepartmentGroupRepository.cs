using System.Linq;
using NHNT.Constants.Statuses;
using NHNT.EF;
using NHNT.Exceptions;
using NHNT.Models;

namespace NHNT.Repositories.Implement
{
    public class DepartmentGroupRepository : IDepartmentGroupRepository
    {
        private readonly DbContextConfig _context;

        public DepartmentGroupRepository(DbContextConfig context)
        {
            _context = context;
        }

        public DepartmentGroup GetById(int id)
        {
            return _context.DepartmentGroups.SingleOrDefault(dg => dg.Id == id);
        }

        public void Add(DepartmentGroup departmentGroup)
        {
            if (departmentGroup == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.DEPARTMENT_GROUP_IS_NULL);
            }

            _context.DepartmentGroups.Add(departmentGroup);
            _context.SaveChanges();
        }

        public void Update(DepartmentGroup departmentGroup)
        {
            if (departmentGroup == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.DEPARTMENT_GROUP_IS_NULL);
            }

            _context.DepartmentGroups.Update(departmentGroup);
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            DepartmentGroup departmentGroup = this.GetById(id);
            if (departmentGroup == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_GROUP_ID);
            }

            _context.DepartmentGroups.Remove(departmentGroup);
            _context.SaveChanges();
        }
    }
}