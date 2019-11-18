using KungFu.Infrastructure.SQLData;

namespace KungFu.Core.DomainService
{
    public interface IDBInit
    {
        void SeedDatabase(KungFuContext ctx);
    }
}