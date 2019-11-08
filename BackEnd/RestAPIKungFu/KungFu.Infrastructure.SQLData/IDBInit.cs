using KungFu.Infrastructure.SQLData;
using System;
using System.Collections.Generic;
using System.Text;

namespace KungFu.Core.DomainService
{
    public interface IDBInit
    {
        void SeedDatabase(KungFuContext ctx);
    }
}
