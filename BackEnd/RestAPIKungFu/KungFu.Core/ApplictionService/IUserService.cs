using KungFu.Entity;
using System;
using System.Collections.Generic;

namespace KungFu.Core.ApplictionService
{
    public interface IUserService
    {
        Tuple<string, string> ValidateUser(Tuple<string, string> attemptToLogin);

        List<User> GetAllUsers();
    }
}