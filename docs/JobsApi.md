# PollinationSDK.Api.JobsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateJob**](JobsApi.md#createjob) | **POST** /projects/{owner}/{name}/jobs | Schedule a job
[**GetJob**](JobsApi.md#getjob) | **GET** /projects/{owner}/{name}/jobs/{job_id} | Get a Job
[**ListJobs**](JobsApi.md#listjobs) | **GET** /projects/{owner}/{name}/jobs | List Jobs



## CreateJob

> CreatedContent CreateJob (string owner, string name, Job job, string authorization = null, string xPollinationToken = null)

Schedule a job

Create a new run.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateJobExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure API key authorization: APIKeyAuth
            Configuration.Default.AddApiKey("x-pollination-token", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("x-pollination-token", "Bearer");
            // Configure HTTP bearer authorization: JWTAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var job = new Job(); // Job | 
            var authorization = authorization_example;  // string |  (optional) 
            var xPollinationToken = xPollinationToken_example;  // string |  (optional) 

            try
            {
                // Schedule a job
                CreatedContent result = apiInstance.CreateJob(owner, name, job, authorization, xPollinationToken);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling JobsApi.CreateJob: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **owner** | **string**|  | 
 **name** | **string**|  | 
 **job** | [**Job**](Job.md)|  | 
 **authorization** | **string**|  | [optional] 
 **xPollinationToken** | **string**|  | [optional] 

### Return type

[**CreatedContent**](CreatedContent.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetJob

> CloudJob GetJob (string owner, string name, string jobId)

Get a Job

Retrieve a job.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetJobExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure API key authorization: APIKeyAuth
            Configuration.Default.AddApiKey("x-pollination-token", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("x-pollination-token", "Bearer");
            // Configure HTTP bearer authorization: JWTAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var jobId = jobId_example;  // string | 

            try
            {
                // Get a Job
                CloudJob result = apiInstance.GetJob(owner, name, jobId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling JobsApi.GetJob: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **owner** | **string**|  | 
 **name** | **string**|  | 
 **jobId** | **string**|  | 

### Return type

[**CloudJob**](CloudJob.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListJobs

> CloudJobList ListJobs (string owner, string name, List<string> ids = null, string status = null, int? page = null, int? perPage = null)

List Jobs

Retrieve a list of jobs.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListJobsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure API key authorization: APIKeyAuth
            Configuration.Default.AddApiKey("x-pollination-token", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("x-pollination-token", "Bearer");
            // Configure HTTP bearer authorization: JWTAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var ids = new List<string>(); // List<string> |  (optional) 
            var status = status_example;  // string |  (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // List Jobs
                CloudJobList result = apiInstance.ListJobs(owner, name, ids, status, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling JobsApi.ListJobs: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **owner** | **string**|  | 
 **name** | **string**|  | 
 **ids** | [**List&lt;string&gt;**](string.md)|  | [optional] 
 **status** | **string**|  | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**CloudJobList**](CloudJobList.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

