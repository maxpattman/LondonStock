using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IStockTypeRepository StockTypeRepository { get; }  
        ITransactionTypeRepository TransactionTypeRepository { get; }
        Task Save();
    }
}
