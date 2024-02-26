using AutoMapper;
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Application.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockType.Queries.GetAllStockType
{
    public class GetAllStockRequestHandler : IRequestHandler<GetAllStockRequest, List<StockTypeDto>>
    {

        private readonly IStockTypeRepository _stockTypeRepository;
        private readonly IMapper _mapper;
        private IDistributedCache _cache;

        public GetAllStockRequestHandler(IStockTypeRepository stockTypeRepository, IMapper mapper, IDistributedCache cache)
        {
            _stockTypeRepository = stockTypeRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<StockTypeDto>> Handle(GetAllStockRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<StockTypeDto>>(await _stockTypeRepository.GetAll());
        }
    }
}
