using Application.DTOs.TransactionType;
using LondonStock.Application.DTOs.StockType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.TransactionType.Queries.GetTransaction
{
    public record GetTransactionRequest(int Id) : IRequest<TransactionTypeDto>;
}
