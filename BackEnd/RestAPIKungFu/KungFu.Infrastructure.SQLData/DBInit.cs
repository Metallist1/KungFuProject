using KungFu.Core.ApplictionService;
using KungFu.Core.DomainService;
using KungFu.Entity;

namespace KungFu.Infrastructure.SQLData
{
    public class DBInit : IDBInit
    {
        private IAuthentication _authentication;

        public DBInit(IAuthentication authHelper)
        {
            _authentication = authHelper;
        }

        public void SeedDatabase(KungFuContext ctx)
        {
            // Create two users with hashed and salted passwords
            string password = "Nedass";
            string password2 = "Yoda";

            var (passwordHashUser1, passwordSaltUser1) = _authentication.CreatePasswordHash(password);
            var (passwordHashUser2, passwordSaltUser2) = _authentication.CreatePasswordHash(password2);

            User user1 = new User()
            {
                Username = "Nedas",
                PasswordHash = passwordHashUser1,
                PasswordSalt = passwordSaltUser1,
                RefreshToken = null,
                IsAdmin = true
            };

            User user2 = new User()
            {
                Username = "CBT",
                PasswordHash = passwordHashUser2,
                PasswordSalt = passwordSaltUser2,
                RefreshToken = null,
                IsAdmin = false
            };
            ctx.Users.Add(user1);
            ctx.Users.Add(user2);
            ctx.SaveChanges();
        }
    }
}