using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Core.ApplictionService
{
    public interface IUserService
    {

        Tuple<string, string, Boolean> ValidateUser(Tuple<string, string> attemptToLogin);

        List<User> GetAllUsers();
    }
}
