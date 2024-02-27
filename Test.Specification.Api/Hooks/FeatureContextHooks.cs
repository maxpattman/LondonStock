using FeatureContext = Test.Specification.LondonStock.Api.Base.FeatureContext;
namespace Test.Specification.LondonStock.Api.Hooks
{
    [Binding]
    public static class FeatureContextHooks
    {
        [BeforeFeature(Order = 0)]
        public static async Task BeforeFeature(TechTalk.SpecFlow.FeatureContext featureContext)
        {
            FeatureContext.Instance = new FeatureContext(featureContext);
            ////await TestRunContext.Instance
            //throw new NotImplementedException();
        }

        [AfterFeature()]
        public static async Task AfterFeature() 
        {

            //await TestRunContext.Instance
                throw new NotImplementedException();
        }
    }
}
