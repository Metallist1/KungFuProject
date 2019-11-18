using KungFu.Entity;
using System.Collections.Generic;

namespace KungFu.Core.DomainService
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();

        void UpdateUser(User user);
    }
}