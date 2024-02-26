using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.TestFramework;

namespace Test.Specification.LondonStock.Api.Base
{
    public abstract class StepBase
    {
        private protected ScenarioContext scenarioContext => ScenarioContext.Instance;
        private protected FeatureContext featureContext => FeatureContext.Instance;
        private protected TestRunContext testRunContext => TestRunContext.Instance;

    }
}
