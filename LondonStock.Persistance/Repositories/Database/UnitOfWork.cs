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
        public IStockTypeRepository StockTypeRepository => throw new NotImplementedException();

        public ITransactionTypeRepository TransactionTypeRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
