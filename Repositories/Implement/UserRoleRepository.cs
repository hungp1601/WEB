using System.Linq;
using Microsoft.EntityFrameworkCore;
using NHNT.Constants.Statuses;
using NHNT.EF;
using NHNT.Exceptions;
using NHNT.Models;

namespace NHNT.Repositories.Implement
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DbContextConfig _context;

        public UserRoleRepository(DbContextConfig context)
        {
            _context = context;
        }
    
        public void Add(UserRole userRole)
        {
            if (userRole == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USER_ROLE_IS_NULL);
            }
                
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void Update(UserRole userRole)
        {
            if (userRole == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USER_ROLE_IS_NULL);
            }

            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
        }
    }
}