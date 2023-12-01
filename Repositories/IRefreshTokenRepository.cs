
using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IRefreshTokenRepository
    {
        RefreshToken GetByRefreshTokenValue(string refreshTokenValue);
        void Add(RefreshToken refreshToken);
        void Update(RefreshToken refreshToken);
    }
}