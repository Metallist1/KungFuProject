using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Boolean IsAdmin { get; set;  }
    }
}
