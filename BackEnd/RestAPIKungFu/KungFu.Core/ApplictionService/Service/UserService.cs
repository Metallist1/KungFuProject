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
           return _userRepo.GetUsers().ToList();
        }

        public Tuple<string, string, Boolean> ValidateUser(Tuple<string, string> attemptAtLogin)
        {
            var user = _userRepo.GetUsers().ToList().FirstOrDefault(u => u.UserName == attemptAtLogin.Item1);

            if(user == null)
            {
                throw new ArgumentException("Invalid User");
            }

            if (!_authentication.VerifyPasswordHash(attemptAtLogin.Item2, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid password");
            }

            return new Tuple<string, string, Boolean>(user.UserName, _authentication.GenerateToken(user), user.IsAdmin); 
        }
    }
}
