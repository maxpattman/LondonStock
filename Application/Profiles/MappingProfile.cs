using Application.DTOs.TransactionType;
using AutoMapper;
using LondonStock.Application.DTOs.StockType;
using LondonStock.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class TransactionTypeProfile : Profile
    {
        public TransactionTypeProfile() 
        {
            CreateMap<TransactionTypeDto, TransactionType>().ReverseMap();
        
        }
    }
}
