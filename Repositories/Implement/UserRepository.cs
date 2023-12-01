using System.Linq;
using Microsoft.EntityFrameworkCore;
using NHNT.Constants.Statuses;
using NHNT.EF;
using NHNT.Exceptions;
using NHNT.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace NHNT.Repositories.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextConfig _context;

        public UserRepository(DbContextConfig context)
        {
            _context = context;
        }
        
        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Username == username);
        }

        public User GetByUsernameAndPassowrd(string username, string password)
        {
            User user = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Username == username);
            if (user != null && BCryptNet.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }

        public void Add(User user)
        {
            if (user == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USER_IS_NULL);
            }
                
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USER_IS_NULL);
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool ExistByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new DataRuntimeException(StatusWrongFormat.USERNAME_IS_EMPTY);
            }

            User user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public bool NotExistByUsername(string username)
        {
            return !ExistByUsername(username);
        }

        public bool ExistByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new DataRuntimeException(StatusWrongFormat.EMAIL_IS_EMPTY);
            }

            User user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public bool ExistByPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new DataRuntimeException(StatusWrongFormat.PHONE_IS_EMPTY);
            }

            User user = _context.Users.SingleOrDefault(u => u.Phone == phone);
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}