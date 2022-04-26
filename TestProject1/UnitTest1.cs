using Kusto.Data;
using Kusto.Data.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var builder = new KustoConnectionStringBuilder("https://help.kusto.windows.net/", "Samples")
                            .WithAadUserPromptAuthentication(); 

            using var queryProvider = KustoClientFactory.CreateCslQueryProvider(builder); // Fails here

            var query = "StormEvents | count | as HowManyRecords; StormEvents | limit 10 | project StartTime, EventType, State | as SampleRecords";
            var reader = queryProvider.ExecuteQuery(query);
        }
    }
}