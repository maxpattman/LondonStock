//using AutoMapper;
//using FluentValidation;
//using LondonStock.Application.Contracts.Persistence;
//using LondonStock.Application.Responses;
//using LondonStock.Application.Validators;
//using LondonStock.Domain.Entity;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LondonStock.Application.Features.StockType.Commands.CreateStockType
//{
//    public class CreateStockCommandHandler
//    {
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        public CreateStockCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<BaseCommandResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
//        {
//            var response = new BaseCommandResponse();
//            var validator = new CreateStockCommandValidator();
//            var validationResult = await validator.ValidateAsync(request.StockTypeDto, cancellationToken);
//            if (validationResult.IsValid == false)
//            {
//                response.Success = false;
//                response.Message = "Creation Failed";
//                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
//            }
//            else
//            {
//                var stockType = _mapper.Map<Stock>(request);

//                stockType = await _unitOfWork.StockTypeRepository.Add(stockType);
//                await _unitOfWork.Save();

//                response.Success = true;
//                response.Message = "Creation Successful";
//                response.Id = stockType.Id;
//            }

//            return response;
//        }
//    }
//}
