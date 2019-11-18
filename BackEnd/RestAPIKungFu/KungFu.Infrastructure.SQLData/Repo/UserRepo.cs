using KungFu.Core.DomainService;
using KungFu.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KungFu.Infrastructure.SQLData.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly KungFuContext _ctx;

        public UserRepo(KungFuContext context)
        {
            _ctx = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _ctx.Users;
        }

        public void UpdateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}