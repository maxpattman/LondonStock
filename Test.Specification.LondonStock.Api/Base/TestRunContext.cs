using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Specification.LondonStock.Api.Models;

namespace Test.Specification.LondonStock.Api.Base
{
    internal sealed class TestRunContext : IDisposable
    {
        private readonly IConfiguration _configuration;
        public TestRunContext()
        {

          
        }

        public static TestRunContext Instance { get; } = new TestRunContext();

        public TestClientSettings testClientSettings { get; set;}
            
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

