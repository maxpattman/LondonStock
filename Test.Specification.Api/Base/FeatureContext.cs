using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Test.Specification.LondonStock.Api.Base
{
    public class FeatureContext
    {
        private readonly TechTalk.SpecFlow.FeatureContext _featureContext;
        public FeatureContext(TechTalk.SpecFlow.FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }
        public static FeatureContext Instance { get; set; }

      
    }
}


