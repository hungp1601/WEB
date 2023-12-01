using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IRoleRepository
    {
        Role GetById(int id);
        Role GetByName(string name);
        void Add(Role role);
        void Update(Role role);
        void Delete(int id);
    }
}