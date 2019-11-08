using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Core.DomainService
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User ValidateUser(User user);
    }
}
