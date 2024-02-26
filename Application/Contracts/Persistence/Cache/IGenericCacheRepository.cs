using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Contracts.Persistence.Cache
{
    public interface IGenericCacheRepository : IDistributedCache
    {

    }
}

