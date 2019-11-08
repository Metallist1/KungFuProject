using KungFu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Core.ApplictionService
{
    public interface IUserService
    {

        LoggedInEntity ValidateUser(LoggingInEntity user);

        List<User> GetAllUsers();
    }
}
