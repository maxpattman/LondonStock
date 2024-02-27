using LondonStock.Application.Contracts.Persistence;
using LondonStock.Domain.Entity;
using LondonStock.Persistance;
using LondonStock.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Persistance.Repositories
{
    public class TransactionTypeRepository : GenericRepository<TransactionType> ,ITransactionTypeRepository
    {
        private readonly LondonStockDBContext _dbContext;

        public TransactionTypeRepository(LondonStockDBContext dbContext) : base(dbContext)
        { 
            _dbContext = dbContext;
    
        }
        public async Task<TransactionType> Add(TransactionType entity)
        {
            await _dbContext.AddAsync(entity);
            
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(TransactionType entity)
        {
            _dbContext.Set<TransactionType>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<TransactionType> Get(int id)
        {
            return await _dbContext.Set<TransactionType>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TransactionType>> GetAll()
        {
            return await _dbContext.Set<TransactionType>().ToListAsync();
        }

        public async Task Update(TransactionType entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
