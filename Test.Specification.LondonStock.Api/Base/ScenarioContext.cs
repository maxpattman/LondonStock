using LondonStock.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Test.Specification.LondonStock.Api.Base
{
    public class ScenarioContext : IDisposable
    {
        private readonly TechTalk.SpecFlow.ScenarioContext _scenarioContext;
        public ScenarioContext(TechTalk.SpecFlow.ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }
        public static ScenarioContext Instance { get; set; }

        public LondonStockClient CreateLondonStockClient()
        {
            return new LondonStockClient("https://localhost:44375/LondonStock", new HttpClient());
        }
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing) { }

    }
}
