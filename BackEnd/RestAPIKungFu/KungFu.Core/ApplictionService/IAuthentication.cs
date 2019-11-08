using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Core.ApplictionService
{
    public interface IAuthentication
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        string GenerateToken(User user);
    }
}
