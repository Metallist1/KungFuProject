using KungFu.Core.DomainService;
using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace KungFu.Core.ApplictionService.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IAuthentication _authentication;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepo userRepo, IAuthentication auth, ITokenService tokenSer)
        {
            _userRepo = userRepo;
            _authentication = auth;
            _tokenService = tokenSer;
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetUsers().ToList();
        }

        public Tuple<string, string> ValidateUser(Tuple<string, string> attemptAtLogin)
        {
            var user = _userRepo.GetUsers().ToList().FirstOrDefault(u => u.Username == attemptAtLogin.Item1);

            if (user == null)
            {
                throw new ArgumentException("Invalid User");
            }

            if (!_authentication.VerifyPasswordHash(attemptAtLogin.Item2, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid password");
            }

            //Generate claims for token
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    };

            if (user.IsAdmin) claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            else claims.Add(new Claim(ClaimTypes.Role, "User"));

            //Generate refresh token and save it for user.

            var generatedToken = _authentication.GenerateRefreshToken();

            _tokenService.SaveRefreshToken(user.Username, generatedToken);

            return new Tuple<string, string>(_authentication.GenerateToken(claims), generatedToken);
        }
    }
}