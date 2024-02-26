using LondonStock.Application.DTOs.TransactionType;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TransactionType
{
    public  class TransactionTypeDto : ITransactionTypeDto
    {
        public int Id { get; set; }
        public string BrokerID { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }


    }
}
