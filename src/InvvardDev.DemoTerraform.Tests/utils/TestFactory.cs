using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;

namespace InvvardDev.DemoTerraform.Tests.utils
{
    public class TestFactory
    {
        public static IEnumerable<object[]> Data()
        {
            return new List<object[]> {
                                          new object[] { "name", "Bill" },
                                          new object[] { "name", "Paul" },
                                          new object[] { "name", "Steve" }
                                      };
        }

        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues> {
                                                              { key, value }
                                                          };

            return qs;
        }

        public static DefaultHttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue)
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext()) {
                                                                               Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue))
                                                                           };

            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            var logger = type == LoggerTypes.List ? new ListLogger() : NullLoggerFactory.Instance.CreateLogger("Null Logger");

            return logger;
        }
    }
}