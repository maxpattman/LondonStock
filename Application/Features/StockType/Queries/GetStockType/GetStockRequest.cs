using LondonStock.Application.DTOs.StockType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockType.Queries.GetStockType
{

    public record GetStockRequest : IRequest<StockTypeDto>
    {
        public string? Ticker { get; init; }

    }

}
