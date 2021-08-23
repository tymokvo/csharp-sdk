# PollinationSDK.Api.AccountsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAccount**](AccountsApi.md#getaccount) | **GET** /accounts/{name} | Get an account by name
[**ListAccounts**](AccountsApi.md#listaccounts) | **GET** /accounts | List Accounts on the Pollination platform



## GetAccount

> AccountPublic GetAccount (string name)

Get an account by name

Retrieve an account by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetAccountExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new AccountsApi(Configuration.Default);
            var name = name_example;  // string | 

            try
            {
                // Get an account by name
                AccountPublic result = apiInstance.GetAccount(name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AccountsApi.GetAccount: " + e.Message );
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
 **name** | **string**|  | 

### Return type

[**AccountPublic**](AccountPublic.md)

### Authorization

No authorization required

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


## ListAccounts

> PublicAccountList ListAccounts (string search = null, string type = null, RoleEnum? role = null, int? page = null, int? perPage = null)

List Accounts on the Pollination platform

List accounts

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListAccountsExample
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

            var apiInstance = new AccountsApi(Configuration.Default);
            var search = search_example;  // string | Search string to find accounts (optional) 
            var type = type_example;  // string | Whether the account is for a user or an org (optional) 
            var role = ;  // RoleEnum? | The role the user has in relation to this account (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // List Accounts on the Pollination platform
                PublicAccountList result = apiInstance.ListAccounts(search, type, role, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AccountsApi.ListAccounts: " + e.Message );
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
 **search** | **string**| Search string to find accounts | [optional] 
 **type** | **string**| Whether the account is for a user or an org | [optional] 
 **role** | **RoleEnum?**| The role the user has in relation to this account | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**PublicAccountList**](PublicAccountList.md)

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

