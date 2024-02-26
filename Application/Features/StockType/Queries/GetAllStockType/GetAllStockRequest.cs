using LondonStock.Application.DTOs.StockType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockType.Queries.GetAllStockType
{
    public record GetAllStockRequest() : IRequest<List<StockTypeDto>>;

}
