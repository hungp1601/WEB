using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IDepartmentGroupRepository
    {
        DepartmentGroup GetById(int id);
        void Add(DepartmentGroup departmentGroup);
        void Update(DepartmentGroup departmentGroup);
        void Delete(int id);
    }
}