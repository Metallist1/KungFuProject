using KungFu.Core.DomainService;
using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KungFu.Core.ApplictionService.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private IAuthentication _authentication;
        public UserService(IUserRepo userRepo, IAuthentication auth)
        {
            _userRepo = userRepo;
            _authentication = auth;
        }

        public List<User> GetAllUsers()
        {
           return _userRepo.GetUsers().ToList() ;
        }

        public LoggedInEntity ValidateUser(LoggingInEntity attemptAtLogin)
        {
            var user = _userRepo.GetUsers().ToList().FirstOrDefault(u => u.UserName == attemptAtLogin.UserName);

            if(user == null)
            {
                throw new ArgumentException("Invalid User");
            }

            if (!_authentication.VerifyPasswordHash(attemptAtLogin.PassWord, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid password");
            }

            LoggedInEntity ent = new LoggedInEntity()
            {
                UserName = user.UserName,
                Token = _authentication.GenerateToken(user),
                IsAdmin = user.IsAdmin,
            };
            return ent;
        }
    }
}
