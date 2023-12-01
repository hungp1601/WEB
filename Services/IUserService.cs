
using NHNT.Dtos;

namespace NHNT.Services
{
    public interface IUserService
    {
        TokenDto Login(string username, string password);
        TokenDto RefreshToken(string accessTokenOld, string refreshToken);
        UserDto GetUserById(int id); 
        UserDto GetUserByUsername(string username);
        TokenDto Register(UserDto dto);
    }
}