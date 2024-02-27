using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.Contracts.Logging;
using AutoMapper;
using Moq;
using Shouldly;
using LondonStock.Application.Profiles;
using LondonStock.Application.Features.StockRequests.Handlers.Queries;
using Test.Unit.Application.Mocks;
using Microsoft.Extensions.Caching.Distributed;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Application.Features.StockType.Queries.GetStockList;

namespace Test.Unit.Application.Features.StockTypes.Queries
{
    public class GetStockListRequestHandlerTests
    {
        private readonly Mock<IStockTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<ILogger<GetStockListRequestHandler>> _mockLogger;
        private Mock<IDistributedCacheExtentionsMethodsWrapper> _mockcache;

        public GetStockListRequestHandlerTests()
        {
            _mockRepo = MockStockTypeRepository.GetMockStockTypeRepository();
            _mockcache = MockCache.GetMockCache();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StockTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockLogger = new Mock<ILogger<GetStockListRequestHandler>>();
        }
        [Fact]
        public async Task GetStockListRequestTest()
        {
            var handler = new GetStockListRequestHandler(_mockRepo.Object,_mapper, _mockcache.Object);
            var tickers = new List<string> { "sas","sat","frw" };
            var request = new GetStockListRequest(tickers);
            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<StockTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}

