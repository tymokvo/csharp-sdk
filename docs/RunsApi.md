# PollinationSDK.Api.RunsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DownloadRunArtifact**](RunsApi.md#downloadrunartifact) | **GET** /projects/{owner}/{name}/runs/{run_id}/artifacts/download | Download an artifact from the run folder
[**GetRun**](RunsApi.md#getrun) | **GET** /projects/{owner}/{name}/runs/{run_id} | Get a Run
[**GetRunOutput**](RunsApi.md#getrunoutput) | **GET** /projects/{owner}/{name}/runs/{run_id}/outputs/{output_name} | Get run output by name
[**GetRunStepLogs**](RunsApi.md#getrunsteplogs) | **GET** /projects/{owner}/{name}/runs/{run_id}/steps/{step_id}/logs | Get the logs of a specific step of the run
[**GetRunSteps**](RunsApi.md#getrunsteps) | **GET** /projects/{owner}/{name}/runs/{run_id}/steps | Query the steps of a run
[**ListRunArtifacts**](RunsApi.md#listrunartifacts) | **GET** /projects/{owner}/{name}/runs/{run_id}/artifacts | List artifacts in a run folder
[**ListRuns**](RunsApi.md#listruns) | **GET** /projects/{owner}/{name}/runs | List runs
[**QueryResults**](RunsApi.md#queryresults) | **GET** /projects/{owner}/{name}/results | Query run results
[**ResumeRun**](RunsApi.md#resumerun) | **PUT** /projects/{owner}/{name}/runs/{run_id}/resume | resume a run
[**StopRun**](RunsApi.md#stoprun) | **PUT** /projects/{owner}/{name}/runs/{run_id}/stop | Stop a run
[**SuspendRun**](RunsApi.md#suspendrun) | **PUT** /projects/{owner}/{name}/runs/{run_id}/suspend | Suspend a run



## DownloadRunArtifact

> AnyType DownloadRunArtifact (string owner, string name, string runId, string path = null)

Download an artifact from the run folder

Get a download link for an artifact in a run folder

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DownloadRunArtifactExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 
            var path = path_example;  // string | The path to an file within a project folder (optional) 

            try
            {
                // Download an artifact from the run folder
                AnyType result = apiInstance.DownloadRunArtifact(owner, name, runId, path);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.DownloadRunArtifact: " + e.Message );
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
 **runId** | **string**|  | 
 **path** | **string**| The path to an file within a project folder | [optional] 

### Return type

[**AnyType**](AnyType.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRun

> Run GetRun (string owner, string name, string runId)

Get a Run

Retrieve a run.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRunExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 

            try
            {
                // Get a Run
                Run result = apiInstance.GetRun(owner, name, runId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.GetRun: " + e.Message );
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
 **runId** | **string**|  | 

### Return type

[**Run**](Run.md)

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


## GetRunOutput

> AnyType GetRunOutput (string owner, string name, string runId, string outputName)

Get run output by name

get run output by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRunOutputExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 
            var outputName = outputName_example;  // string | 

            try
            {
                // Get run output by name
                AnyType result = apiInstance.GetRunOutput(owner, name, runId, outputName);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.GetRunOutput: " + e.Message );
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
 **runId** | **string**|  | 
 **outputName** | **string**|  | 

### Return type

[**AnyType**](AnyType.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRunStepLogs

> string GetRunStepLogs (string owner, string name, string runId, string stepId)

Get the logs of a specific step of the run

get run step logs

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRunStepLogsExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 
            var stepId = stepId_example;  // string | 

            try
            {
                // Get the logs of a specific step of the run
                string result = apiInstance.GetRunStepLogs(owner, name, runId, stepId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.GetRunStepLogs: " + e.Message );
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
 **runId** | **string**|  | 
 **stepId** | **string**|  | 

### Return type

**string**

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


## GetRunSteps

> StepList GetRunSteps (string owner, string name, string runId, string status = null, List<string> stepId = null, string untilGeneration = null, string sinceGeneration = null, int? page = null, int? perPage = null)

Query the steps of a run

list run steps

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRunStepsExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 
            var status = status_example;  // string |  (optional) 
            var stepId = new List<string>(); // List<string> |  (optional) 
            var untilGeneration = untilGeneration_example;  // string |  (optional) 
            var sinceGeneration = sinceGeneration_example;  // string |  (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // Query the steps of a run
                StepList result = apiInstance.GetRunSteps(owner, name, runId, status, stepId, untilGeneration, sinceGeneration, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.GetRunSteps: " + e.Message );
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
 **runId** | **string**|  | 
 **status** | **string**|  | [optional] 
 **stepId** | [**List&lt;string&gt;**](string.md)|  | [optional] 
 **untilGeneration** | **string**|  | [optional] 
 **sinceGeneration** | **string**|  | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**StepList**](StepList.md)

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


## ListRunArtifacts

> List&lt;FileMeta&gt; ListRunArtifacts (string owner, string name, string runId, int? page = null, int? perPage = null, List<string> path = null)

List artifacts in a run folder

Retrieve a list of artifacts in a run folder

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListRunArtifactsExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)
            var path = new List<string>(); // List<string> | The path to an file within a project folder (optional) 

            try
            {
                // List artifacts in a run folder
                List<FileMeta> result = apiInstance.ListRunArtifacts(owner, name, runId, page, perPage, path);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.ListRunArtifacts: " + e.Message );
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
 **runId** | **string**|  | 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]
 **path** | [**List&lt;string&gt;**](string.md)| The path to an file within a project folder | [optional] 

### Return type

[**List&lt;FileMeta&gt;**](FileMeta.md)

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


## ListRuns

> RunList ListRuns (string owner, string name, string status = null, List<string> jobId = null, int? page = null, int? perPage = null)

List runs

Retrieve a list of runs.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListRunsExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var status = status_example;  // string |  (optional) 
            var jobId = new List<string>(); // List<string> |  (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // List runs
                RunList result = apiInstance.ListRuns(owner, name, status, jobId, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.ListRuns: " + e.Message );
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
 **status** | **string**|  | [optional] 
 **jobId** | [**List&lt;string&gt;**](string.md)|  | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**RunList**](RunList.md)

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


## QueryResults

> RunResultList QueryResults (string owner, string name, string status = null, List<string> jobId = null, int? page = null, int? perPage = null)

Query run results

Retrieve a list of run results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class QueryResultsExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var status = status_example;  // string |  (optional) 
            var jobId = new List<string>(); // List<string> |  (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // Query run results
                RunResultList result = apiInstance.QueryResults(owner, name, status, jobId, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.QueryResults: " + e.Message );
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
 **status** | **string**|  | [optional] 
 **jobId** | [**List&lt;string&gt;**](string.md)|  | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**RunResultList**](RunResultList.md)

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


## ResumeRun

> Accepted ResumeRun (string owner, string name, string runId)

resume a run

resume a run

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ResumeRunExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 

            try
            {
                // resume a run
                Accepted result = apiInstance.ResumeRun(owner, name, runId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.ResumeRun: " + e.Message );
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
 **runId** | **string**|  | 

### Return type

[**Accepted**](Accepted.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## StopRun

> Accepted StopRun (string owner, string name, string runId)

Stop a run

Stop a run.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class StopRunExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 

            try
            {
                // Stop a run
                Accepted result = apiInstance.StopRun(owner, name, runId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.StopRun: " + e.Message );
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
 **runId** | **string**|  | 

### Return type

[**Accepted**](Accepted.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## SuspendRun

> Accepted SuspendRun (string owner, string name, string runId)

Suspend a run

Stop a run.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class SuspendRunExample
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

            var apiInstance = new RunsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var runId = runId_example;  // string | 

            try
            {
                // Suspend a run
                Accepted result = apiInstance.SuspendRun(owner, name, runId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RunsApi.SuspendRun: " + e.Message );
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
 **runId** | **string**|  | 

### Return type

[**Accepted**](Accepted.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

