using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;

namespace Google_BigQueryResults_XUnit_Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(Program)}.{nameof(Main)} started.");

            var stackOverflowRepository = new StackOverflowRepository(new LocalBigQueryClient());
            stackOverflowRepository.QueryPosts();

            Console.WriteLine($"{nameof(Program)}.{nameof(Main)} completed.");
        }

    }
}