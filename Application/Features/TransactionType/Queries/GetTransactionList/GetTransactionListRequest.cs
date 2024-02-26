using Application.DTOs.TransactionType;
using LondonStock.Application.DTOs.StockType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.TransactionType.Queries.GetTransactionList
{
    public class GetTransactionListRequest : IRequest<List<TransactionTypeDto>>
    {
        public int Id { get; }
    }
}
