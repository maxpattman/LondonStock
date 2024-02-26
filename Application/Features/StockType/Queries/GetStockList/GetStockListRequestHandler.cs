using AutoMapper;
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Application.Extensions;
using LondonStock.Application.Features.StockType.Queries.GetStockList;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockRequests.Handlers.Queries
{
    public class GetStockListRequestHandler : IRequestHandler<GetStockListRequest, List<StockTypeDto>>
    {

        private readonly IStockTypeRepository _stockTypeRepository;
        private readonly IMapper _mapper;
        private IDistributedCache _cache;

        public GetStockListRequestHandler(IStockTypeRepository stockTypeRepository, IMapper mapper, IDistributedCache cache)
        {
            _stockTypeRepository = stockTypeRepository;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<List<StockTypeDto>> Handle(GetStockListRequest request, CancellationToken cancellationToken) 
        {
            List<StockTypeDto> results = new List<StockTypeDto>();

            var tickers = request._tickers;

            foreach (var ticker in tickers.ToList())
            {
                // look in the cache first 
                var stock = await _cache.GetRecordAsync<StockTypeDto>(ticker, cancellationToken);

                if (stock == null)
                {
                    results.Add(_mapper.Map<StockTypeDto>(await _stockTypeRepository.Get(ticker)));
                }
                else 
                {
                    results.Add(stock);
                }
            }

            return _mapper.Map<List<StockTypeDto>>(results);
        }

        
    }
}
