using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.DTOs.StockType
{
    public interface IStockTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Price { get; set; }
    }
}
