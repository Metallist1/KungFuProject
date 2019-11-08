using KungFu.Core.DomainService;
using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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

        public User ValidateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
