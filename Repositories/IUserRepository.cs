
using System;
using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByUsername(string username);
        User GetByUsernameAndPassowrd(string username, string password);
        Boolean ExistByUsername(string username);
        Boolean NotExistByUsername(string username);
        Boolean ExistByEmail(string email);
        Boolean ExistByPhone(string phone);
        void Add(User user);
        void Update(User user);
    }
}