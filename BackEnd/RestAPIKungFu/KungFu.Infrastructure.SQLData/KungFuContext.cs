using KungFu.Entity;
using Microsoft.EntityFrameworkCore;

namespace KungFu.Infrastructure.SQLData
{
    public class KungFuContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public KungFuContext(DbContextOptions<KungFuContext> opt) : base(opt)
        {
        }
    }
}