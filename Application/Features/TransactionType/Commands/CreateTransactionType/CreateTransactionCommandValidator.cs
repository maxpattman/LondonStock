using FluentValidation;
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.Features.StockType.Commands.CreateStockType;
using LondonStock.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.TransactionType.Commands.CreateTransactionType
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        public CreateTransactionCommandValidator(ITransactionTypeRepository transactionTypeRepository)
        {

            RuleFor(p => p.TransactionTypeDto.Ticker).Matches("[A - Z]{ 3}");

            this._transactionTypeRepository = transactionTypeRepository;
        }

    }
}
