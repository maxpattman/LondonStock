using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.DTOs.StockType
{
    public class StockTypeDto : BaseDto, IStockTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Price { get; set; }
    }
}
