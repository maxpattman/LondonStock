using LondonStock.Client;
using System;
using TechTalk.SpecFlow;
using Test.Specification.LondonStock.Api.Base;
using FluentAssertions;

namespace Test.Specification.LondonStock.Api.StepDefinitions
{
    [Binding]
    public class GetStockStepDefinitions : StepBase
    {
       private LondonStockClient _client;
        public GetStockStepDefinitions()
        {
            _client = scenarioContext.CreateLondonStockClient();
        }


        [Given(@"Request for current value of stock TickerSymbol=\(""([^""]*)""\) GET current value of stock")]
        public async void GivenRequestForCurrentValueOfStockTickerSymbolGETCurrentValueOfStock(string ticker)
        {

            var stock = await  _client.GetAsync(ticker);

              
        }

        [Then(@"The Response should be a success")]
        public void ThenTheResponseShouldBeASuccess()
        {
            Console.WriteLine("Filler");
        }

        [Given(@"Request for all stocks \* GET current values of all stocks on the market")]
        public void GivenRequestForAllStocksGETCurrentValuesOfAllStocksOnTheMarket()
        {
            throw new PendingStepException();
        }

        [Given(@"Request for list of stocks with supplied list of TickerSymbols \(\*\) GET current values of requested stocks")]
        public void GivenRequestForListOfStocksWithSuppliedListOfTickerSymbolsGETCurrentValuesOfRequestedStocks()
        {
            throw new PendingStepException();
        }

        [When(@"\[action]")]
        public void WhenAction()
        {
            throw new PendingStepException();
        }
    }
}
