using LondonStock.Application.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LondonStock.Application.Extensions
{
    public static class DistributedCacheExtentions 
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData,options);
        }


        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId, CancellationToken cancellationToken) 
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if (jsonData is null)
            {
                return default(T);
                
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
    
}

public interface IDistributedCacheExtentionsMethodsWrapper : IDistributedCache
{

    Task SetRecordAsync<T>(IDistributedCache cache,string recordId,T data,TimeSpan? absoluteExpireTime = null,TimeSpan? unusedExpireTime = null);

    Task<T> GetRecordAsync<T>(IDistributedCache cache, string recordId, CancellationToken cancellationToken);

    public IDistributedCache _cache { get; set; }
}

public class DistributedCacheExtentionsMethodsWrapper : IDistributedCacheExtentionsMethodsWrapper 
{
    public IDistributedCache _cache { get ; set ; }

    public byte[] Get(string key)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]> GetAsync(string key, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetRecordAsync<T>(IDistributedCache cache, string recordId, CancellationToken cancellationToken)
    {
        return DistributedCacheExtentions.GetRecordAsync<T>(cache, recordId, cancellationToken);
    }

    public void Refresh(string key)
    {
        throw new NotImplementedException();
    }

    public Task RefreshAsync(string key, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(string key)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string key, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        throw new NotImplementedException();
    }

    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task SetRecordAsync<T>(IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null) 
    {
        return DistributedCacheExtentions.SetRecordAsync<T>(cache, recordId, data, absoluteExpireTime, unusedExpireTime);
    }

}
