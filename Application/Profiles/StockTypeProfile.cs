using Application.DTOs.TransactionType;
using AutoMapper;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Profiles
{
    public class StockTypeProfile : Profile
    {
        public StockTypeProfile()
        {
            CreateMap<StockTypeDto, StockType>().ReverseMap();
            CreateMap<TransactionTypeDto, TransactionType>().ReverseMap();

        }
    }
}