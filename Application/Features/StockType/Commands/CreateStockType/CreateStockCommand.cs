using LondonStock.Application.Responses;
using LondonStock.Application.DTOs.StockType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockType.Commands.CreateStockType
{
    public class CreateStockCommand : IRequest<BaseCommandResponse>
    {
        public CreateStockTypeDto TransactionTypeDto { get; set; }
    }
}
