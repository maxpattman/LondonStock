using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Application.Extensions;
using LondonStock.Domain.Entity;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Test.Unit.Application.Mocks
{
    public class MockCache
    {
        public static Mock<IDistributedCacheExtentionsMethodsWrapper> GetMockCache()
        {
            var mockCache = new Mock<IDistributedCacheExtentionsMethodsWrapper>();
            mockCache.SetupGet(x => x._cache = new Mock<IDistributedCache>());

            //mockCache.Setup(c => c.GetRecordAsync<StockTypeDto>(c._cache, It.IsAny<string>(), It.IsAny<CancellationToken>())



            mockCache.Setup(x => x.GetRecordAsync<StockTypeDto>(
                x._cache,
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync((Task<StockTypeDto> i) => It.IsAny<StockTypeDto>()); ;


            //mockCache.Setup(x =>
            //            x.GetRecordAsync<StockTypeDto>(
            //                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            //                                    .ReturnsAsync(StockTypeDto stock);

            return mockCache;
        }
    }
}