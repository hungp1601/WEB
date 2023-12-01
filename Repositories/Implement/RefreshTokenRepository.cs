using System.Linq;
using NHNT.EF;
using NHNT.Models;

namespace NHNT.Repositories.Implement
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DbContextConfig _context;

        public RefreshTokenRepository(DbContextConfig context)
        {
            _context = context;
        }

        public RefreshToken GetByRefreshTokenValue(string refreshTokenValue)
        {
            return _context.RefreshTokens.SingleOrDefault(rf => rf.Value == refreshTokenValue);
        }

        public void Add(RefreshToken refreshToken)
        {
            if (refreshToken == null)
                return;

            _context.RefreshTokens.Add(refreshToken);
            _context.SaveChanges();
        }

        public void Update(RefreshToken refreshToken)
        {
            if (refreshToken == null)
                return;

            _context.RefreshTokens.Update(refreshToken);
            _context.SaveChanges();
        }
    }
}