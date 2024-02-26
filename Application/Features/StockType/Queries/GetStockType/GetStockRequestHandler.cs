using AutoMapper;
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Application.Extensions;
using LondonStock.Application.Features.StockType.Queries.GetStockType;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockRequests.Handlers.Queries
{
    public class GetStockRequestHandler : IRequestHandler<GetStockRequest, StockTypeDto>
    {

        private readonly IStockTypeRepository _stockTypeRepository;
        private readonly IMapper _mapper;
        private IDistributedCache _cache;
        

        public GetStockRequestHandler(IStockTypeRepository stockTypeRepository, IMapper mapper,IDistributedCache cache)
        {
            _stockTypeRepository = stockTypeRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<StockTypeDto> Handle(GetStockRequest request, CancellationToken cancellationToken)
        {
            /// Look in the cache first 
            var stock = await _cache.GetRecordAsync<StockTypeDto>(request.Ticker, cancellationToken);

            if (stock == null)
            {
                var stocsk = await _stockTypeRepository.Get(request.Ticker);
                return _mapper.Map<StockTypeDto>(stocsk);
            }

           return _mapper.Map<StockTypeDto>(stock);

        }

    }
}
