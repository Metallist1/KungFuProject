using KungFu.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Infrastructure.SQLData
{
    public class KungFuContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public KungFuContext(DbContextOptions<KungFuContext> opt) : base(opt)
        {

        }
    }
}
