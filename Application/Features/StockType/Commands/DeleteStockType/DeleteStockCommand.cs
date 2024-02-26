using LondonStock.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.StockType.Commands.DeleteStockType
{
    public class DeleteStockCommand : IRequest<BaseCommandResponse>
    {
        public string Id { get; set; }
    }
}
