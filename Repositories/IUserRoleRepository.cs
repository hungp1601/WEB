using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IUserRoleRepository
    {
        void Add(UserRole userRole);
        void Update(UserRole userRole);
    }
}