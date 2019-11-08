using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Entity
{
    public class LoggedInEntity
    {
        public string UserName { get; set; }
        public Boolean IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
