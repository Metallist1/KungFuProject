using KungFu.Core.DomainService;
using System.Linq;

namespace KungFu.Core.ApplictionService.Service
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepo _userRepo;

        public TokenService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public string getRefreshToken(string username)
        {
            var user = _userRepo.GetUsers().ToList().FirstOrDefault(u => u.Username == username);
            return user.RefreshToken;
        }

        public void SaveRefreshToken(string username, string refreshToSave)
        {
            var user = _userRepo.GetUsers().ToList().FirstOrDefault(u => u.Username == username);
            user.RefreshToken = refreshToSave;
            _userRepo.UpdateUser(user);
        }
    }
}