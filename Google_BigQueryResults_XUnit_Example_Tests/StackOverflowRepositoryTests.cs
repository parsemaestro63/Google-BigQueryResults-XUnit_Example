using Google_BigQueryResults_XUnit_Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Auth.OAuth2;

namespace Google_BigQueryResults_Example_Tests
{
    public class StackOverflowRepositoryTests
    {

        [Fact]
        public void StackOverflowRepositoryTest_BaseCase_ProvidesListWithBigQueryResults()
        {
            // TODO: complete setting up, and re-design as a fixture or generator class.
            var getQueryResultsResponse = new GetQueryResultsResponse();

            var tableRow = new TableRow();

            var urlField = new TableCell();
            urlField.ETag = "url";
            urlField.V = "https://stackoverflow.com/questions/35159967";

            var viewCountField = new TableCell();
            viewCountField.ETag = "view_count";
            viewCountField.V = "88467";

            tableRow.F = new List<TableCell> { urlField, viewCountField };

            getQueryResultsResponse.Rows = new List<TableRow> { tableRow };
            getQueryResultsResponse.TotalRows = 1;

            getQueryResultsResponse.Schema = new TableSchema();
            getQueryResultsResponse.Schema.Fields = new List<TableFieldSchema>();

            var urlData = new TableFieldSchema
            {
                Name = "url",
                Mode = "NULLABLE",
                Type = "STRING"
            };

            var viewCountData = new TableFieldSchema
            {
                Name = "view_count",
                Mode = "NULLABLE",
                Type = "STRING"
            };

            getQueryResultsResponse.Schema.Fields.Add(urlData);
            getQueryResultsResponse.Schema.Fields.Add(viewCountData);

            var tableReference = new TableReference
            {
                DatasetId = "DatasetId",
                ProjectId = "ProjectId",
                TableId = "TableId",
                ETag = "url"
            };

            var bigQueryResults = new BigQueryResults(
                BigQueryClient.Create("ProjectId", GoogleCredential.FromAccessToken("AccessToken")),
                getQueryResultsResponse,
                tableReference,
                new GetQueryResultsOptions());

            var localBigQueryClient = new Mock<ILocalBigQueryClient>();

            localBigQueryClient.Setup(client => client.GetQueryResult(It.IsAny<string>())).Returns(bigQueryResults);

            var subject = new StackOverflowRepository(localBigQueryClient.Object);

            var posts = subject.QueryPosts();

            Assert.Single(posts);
            Assert.Equal("https://stackoverflow.com/questions/35159967", posts[0]["url"]);
            Assert.Equal("88467", posts[0]["view_count"]);
        }
    }
}