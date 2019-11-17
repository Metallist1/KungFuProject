using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Core.ApplictionService
{
    public interface IAuthentication
    {
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        string GenerateToken(User user);

        string RefreshToken(String token);
    }
}
