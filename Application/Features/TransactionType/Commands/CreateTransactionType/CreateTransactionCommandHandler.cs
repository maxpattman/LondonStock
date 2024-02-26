
using AutoMapper;
using FluentValidation;
using LondonStock.Application.Contracts.Persistence;
using LondonStock.Application.Responses;
using LondonStock.Domain.Entity;
using LondonStock.Application.Validators;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Features.TransactionType.Commands.CreateTransactionType
{
    public class CreateTransactionCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private IDistributedCache _cache;
        private ITransactionTypeRepository _transactionTypeRepository;

        public CreateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache, ITransactionTypeRepository transactionTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTransactionCommandValidator(_transactionTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var transactionType = _mapper.Map<Domain.Entity.TransactionType>(request);

                transactionType = await _unitOfWork.TransactionTypeRepository.Add(transactionType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = transactionType.Id.ToString();
            }

            return response;
        }
    }
}



