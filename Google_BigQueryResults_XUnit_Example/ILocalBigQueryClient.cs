using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_BigQueryResults_XUnit_Example
{
    public interface ILocalBigQueryClient
    {
        BigQueryResults GetQueryResult(string query);
    }
}