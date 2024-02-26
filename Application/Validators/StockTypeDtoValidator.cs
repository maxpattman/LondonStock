using FluentValidation;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Validators
{
    public class StockTypeDtoValidator : AbstractValidator<StockTypeDto>
    {
        public StockTypeDtoValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Ticker).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
