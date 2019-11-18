using System.Collections.Generic;
using System.Security.Claims;

namespace KungFu.Core.ApplictionService
{
    public interface IAuthentication
    {
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        string GenerateToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal getExpiredPrincipal(string token);
    }
}