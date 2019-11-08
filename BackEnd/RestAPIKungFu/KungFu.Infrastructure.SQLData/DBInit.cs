using KungFu.Core.ApplictionService;
using KungFu.Core.DomainService;
using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Infrastructure.SQLData
{
    public  class DBInit: IDBInit
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
            byte[] passwordHashUser1, passwordSaltUser1, passwordHashUser2, passwordSaltUser2;
            _authentication.CreatePasswordHash(password, out passwordHashUser1, out passwordSaltUser1);
            _authentication.CreatePasswordHash(password2, out passwordHashUser2, out passwordSaltUser2);

            User user1 = new User()
            {
                UserName = "Nedas",
                PasswordHash = passwordHashUser1,
                PasswordSalt = passwordSaltUser1,
                IsAdmin = true
            };
            User user2 = new User()
            {
                UserName = "CBT",
                PasswordHash = passwordHashUser2,
                PasswordSalt = passwordSaltUser2,
                IsAdmin = false
            };
            ctx.Users.Add(user1);
            ctx.Users.Add(user2);
            ctx.SaveChanges();
        }
    }
}
