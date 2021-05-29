# Overview
Included here is an example test setup of Google Cloud's `BigQueryResults` object written in C#, used to test any dependencies on `BigQueryResults` in code.

## Background
Issuing a query to Google Cloud's BigQuery service via `Google.Cloud.BigQuery.V2.BigQueryClient` returns a `BigQueryResults` in response. Unit testing code depending on the results is not a straight-forward matter, and surprisingly, there's little (or no) Google Cloud documentation nor web guides that provide assistance.

___Here's a set of Google search results:___

<img src="docs/BigQueryResults_Unit_Test_Google_Search.png" width="400px" />

# Setting Up / Running
## Tests
The example unit test is the area of focus here. To run the unit test, run the following commands once you've cloned the project.

```shell script
cd Google_BigQueryResults_XUnit_Example_Tests/
dotnet test
``` 

## Program
To run the program, a [Google Cloud](https://cloud.google.com/) project, and a [service account key](https://console.cloud.google.com/iam-admin/serviceaccounts) are required.

Further setup:
1. Once a service account key is obtained, download and place it in the `Google_BigQueryResults_XUnit_Example` folder
2. Setup environment variables

```shell script
cd Google_BigQueryResults_XUnit_Example
export GCP_PROJECT_ID={project_id}
export GOOGLE_APPLICATION_CREDENTIALS={path_to_key_file}
```

3. Run the project: `dotnet run`


