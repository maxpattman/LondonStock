using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Specification.LondonStock.Api.Base;
using TechTalk.SpecFlow;
using ScenarioContext = Test.Specification.LondonStock.Api.Base.ScenarioContext;

namespace Test.Specification.LondonStock.Api.Hooks
{
    [Binding]
    public class ScenarioContextHooks
    {
        [BeforeScenario(Order = 0)]
        public void BeforeScenario(TechTalk.SpecFlow.ScenarioContext scenarioContext) 
        {
            ScenarioContext.Instance = new ScenarioContext(scenarioContext);
        }
    }
}
