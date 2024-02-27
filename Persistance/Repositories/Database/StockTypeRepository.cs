using LondonStock.Application.Contracts.Persistence;
using LondonStock.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LondonStock.Persistance.Repositories
{
    public class StockTypeRepository : GenericRepository<StockType>, IStockTypeRepository
    {
        private readonly LondonStockDBContext _dbContext;
        public StockTypeRepository(LondonStockDBContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StockType> Get(string ticker) 
        {
            var stockType = await _dbContext.Set<StockType>().FindAsync(ticker);
            return stockType;
        }

    }
    
    
}
