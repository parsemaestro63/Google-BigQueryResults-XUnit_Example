using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_BigQueryResults_XUnit_Example
{
    public class LocalBigQueryClient: ILocalBigQueryClient
    {
        private readonly BigQueryClient _bigQueryClient;

        public LocalBigQueryClient()
        {
            _bigQueryClient = BigQueryClient.Create(Environment.GetEnvironmentVariable("GCP_PROJECT_ID"));
        }

        public BigQueryResults GetQueryResult(string query)
        {
            Console.WriteLine($"{nameof(LocalBigQueryClient)}.{nameof(GetQueryResult)} started.");

            var queryResults = _bigQueryClient.ExecuteQuery(query, parameters: null);

            Console.WriteLine($"{nameof(LocalBigQueryClient)}.{nameof(GetQueryResult)} completed.");

            return queryResults;
        }
    }
}
