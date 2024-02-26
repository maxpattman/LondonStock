using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using LondonStock.Api;

namespace Test.Specification.LondonStock.Api.Hooks
{
    [Binding]
    public static class TestRunHooks
    {
        private static IHost _host;

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            _host = Program.CreateHostBuilder(null).Build();
            _host.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host.StopAsync().Wait();
        }
    }
}
