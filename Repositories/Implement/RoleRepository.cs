using System.Linq;
using NHNT.Constants.Statuses;
using NHNT.EF;
using NHNT.Exceptions;
using NHNT.Models;

namespace NHNT.Repositories.Implement
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContextConfig _context;
        
        public RoleRepository(DbContextConfig context)
        {
            _context = context;
        }
        
        public Role GetById(int id)
        {
            return _context.Roles.SingleOrDefault(r => r.Id == id);
        }

        public Role GetByName(string name)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == name);
        }

        public void Add(Role role)
        {
            if (role == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.ROLE_IS_NULL);
            }
                
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Update(Role role)
        {
            if (role == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.ROLE_IS_NULL);
            }
                
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Role role = this.GetById(id);
            if (role == null)
            {
                throw new DataRuntimeException(StatusNotExist.ROLE_ID);
            }
                
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}