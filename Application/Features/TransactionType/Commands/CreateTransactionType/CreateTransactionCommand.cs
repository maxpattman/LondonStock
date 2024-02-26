using Application.DTOs.TransactionType;
using LondonStock.Application.DTOs.TransactionType;
using LondonStock.Application.Responses;
using MediatR;

namespace LondonStock.Application.Features.TransactionType.Commands.CreateTransactionType
{
    public class CreateTransactionCommand : IRequest<BaseCommandResponse>
    {
        public TransactionTypeDto TransactionTypeDto { get; set; }
    }
}