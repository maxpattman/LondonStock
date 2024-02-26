using LondonStock.Application.Contracts.Persistence;
using LondonStock.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Persistance.Repositories
{
    public class StockTypeRepository : GenericRepository<StockType>, IStockTypeRepository
    {
        private readonly LondonStockDBContext _dbContext;
        public StockTypeRepository(LondonStockDBContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

     

        public async Task<StockType> Add(StockType entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(StockType entity)
        {
            _dbContext.Set<StockType>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<StockType> Get(int id)
        {
            return await _dbContext.Set<StockType>().FindAsync(id);
        }

        public async Task<StockType> Get(string ticker) 
        {
            //return await _dbContext.Set<StockType>().FindAsync(ticker);
            var result = await _dbContext.Set<StockType>().FindAsync(ticker);
            return result;
        }

        public async Task<IReadOnlyList<StockType>> GetAll()
        {
            var result = await _dbContext.Stocks.ToListAsync();
            return result;
        }

        public async Task Update(StockType entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


    }
    
    
}
