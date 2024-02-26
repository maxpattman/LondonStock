using LondonStock.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Domain.Entity
{
    public class TransactionType : BaseDomainEntity
    {
        public int Id {  get; set; }
        public string BrokerID { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }

    }
}
