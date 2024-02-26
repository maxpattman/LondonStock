using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Specification.LondonStock.Api.Models
{
    public class TestClientSettings
    {
        public string BaseUrl { get; set; }
        public HttpClient HttpClient { get; set; }

    }
}
