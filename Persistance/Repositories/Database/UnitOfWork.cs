using LondonStock.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
      private readonly LondonStockDBContext _dbContext;

        public UnitOfWork(LondonStockDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
