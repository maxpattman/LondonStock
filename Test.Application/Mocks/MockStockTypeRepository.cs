using LondonStock.Application.Contracts.Persistence;
using LondonStock.Domain.Entity;
using Moq;
using StackExchange.Redis;
using LondonStock.Domain.Entity;
using LondonStock.Application.DTOs.StockType;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Test.Unit.Application.Mocks
{
    public class MockStockTypeRepository
    {
        public static Mock<IStockTypeRepository> GetMockStockTypeRepository()
        {
            var stockTypeList = new List<StockType>
            {
               new StockType
                {
                    Id = "1",
                    Name = "testStock",
                    Ticker = "sas",
                    Price = "500",

                }, new StockType
                {
                    Id = "2",
                    Name = "testStock2",
                    Ticker = "frw",
                    Price = "350"
                }, new StockType
                {
                    Id = "3",
                    Name = "testStock3",
                    Ticker = "sat",
                    Price = "500",

                } };

            var mockRepo = new Mock<IStockTypeRepository>();
            // mock methods 

            //Task<List<StockTypeRepository>> Get(string);
            mockRepo.Setup(x => x.Get(
                It.IsAny<string>())).ReturnsAsync((StockType i) => stockTypeList.Where(
                x => x.Ticker == i.Ticker).Single());

            //Task<List<T>> GetAll();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(stockTypeList);

            //Task<T> Add(T entity);
            //mockRepo.Setup(x => x.Add(It.IsAny<StockType>()));

            //Task<bool> Exists(int id);

            //Task Update(T entity);

            //Task Delete(T entity);







            return mockRepo;
        }
    }
}