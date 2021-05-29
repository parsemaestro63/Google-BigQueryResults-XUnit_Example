using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Google_BigQueryResults_XUnit_Example
{
    public class StackOverflowRepository
    {
        readonly ILocalBigQueryClient _bigQueryClient;

        public StackOverflowRepository(ILocalBigQueryClient bigQueryClient)
        {
            _bigQueryClient = bigQueryClient;
        }

        public List<Dictionary<string, string>> QueryPosts()
        {
            Console.WriteLine($"{nameof(StackOverflowRepository)}.{nameof(QueryPosts)} started.");

            string query = @"SELECT
                CONCAT(
                    'https://stackoverflow.com/questions/',
                    CAST(id as STRING)) as url, view_count
                FROM `bigquery-public-data.stackoverflow.posts_questions`
                WHERE tags like '%google-bigquery%'
                ORDER BY view_count DESC
                LIMIT 10";

            var queryResult = _bigQueryClient.GetQueryResult(query);

            var resultDictionary = new List<Dictionary<string, string>>();

            foreach (var row in queryResult)
            {
                // Console.WriteLine($"url: {row["url"]}; view_count: {row["view_count"]}");

                var dictionary = new Dictionary<string, string>
                {
                    {  "url", row["url"].ToString() },
                    {  "view_count", row["view_count"].ToString() }
                };

                resultDictionary.Add(dictionary);
            }

            Console.WriteLine($"{nameof(StackOverflowRepository)}.{nameof(QueryPosts)} completed.");

            return resultDictionary;
        }
    }
}
