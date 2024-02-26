using LondonStock.Application.DTOs.StockType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockType.Queries.GetStockList
{
    public record GetStockListRequest(List<string> tickers) : IRequest<List<StockTypeDto>>
    {
        public List<string> _tickers = tickers;
    }

}

