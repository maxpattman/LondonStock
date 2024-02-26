using LondonStock.Application.DTOs.StockType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.DTOs.TransactionType
{
    public interface ITransactionTypeDto
    {
        int Id { get; set; }
        public string BrokerID { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }

    }
}
