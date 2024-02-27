using LondonStock.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Contracts.Persistence
{
    public interface IStockTypeRepository : IGenericRepository<StockType>
    {
        Task<StockType> Get(string ticker);
        
    }
}
