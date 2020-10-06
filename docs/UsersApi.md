# PollinationSDK.Api.UsersApi

All URIs are relative to *https://api.pollination.cloud*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CheckUsername**](UsersApi.md#checkusername) | **GET** /users/check_username/{username} | Check if a username is already taken
[**GetOneUser**](UsersApi.md#getoneuser) | **GET** /users/{name} | Get a specific user profile
[**ListUsers**](UsersApi.md#listusers) | **GET** /users | List Users



## CheckUsername

> AnyType CheckUsername (string username)

Check if a username is already taken

Check if a username is already taken by a user or an org

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CheckUsernameExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UsersApi(Configuration.Default);
            var username = username_example;  // string | 

            try
            {
                // Check if a username is already taken
                AnyType result = apiInstance.CheckUsername(username);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.CheckUsername: " + e.Message );
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
 **username** | **string**|  | 

### Return type

[**AnyType**](AnyType.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Username not taken |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetOneUser

> UserPublic GetOneUser (string name)

Get a specific user profile

Get a specific user profile by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOneUserExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UsersApi(Configuration.Default);
            var name = name_example;  // string | 

            try
            {
                // Get a specific user profile
                UserPublic result = apiInstance.GetOneUser(name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.GetOneUser: " + e.Message );
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

[**UserPublic**](UserPublic.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListUsers

> UserPublicList ListUsers (int? page = null, int? perPage = null, string name = null, string username = null, List<string> id = null)

List Users

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListUsersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UsersApi(Configuration.Default);
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)
            var name = name_example;  // string | Name of the user to search for (optional) 
            var username = username_example;  // string | Username of the user to search for (optional) 
            var id = new List<string>(); // List<string> | A list of users to search for by their user ID (optional) 

            try
            {
                // List Users
                UserPublicList result = apiInstance.ListUsers(page, perPage, name, username, id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.ListUsers: " + e.Message );
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
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]
 **name** | **string**| Name of the user to search for | [optional] 
 **username** | **string**| Username of the user to search for | [optional] 
 **id** | [**List&lt;string&gt;**](string.md)| A list of users to search for by their user ID | [optional] 

### Return type

[**UserPublicList**](UserPublicList.md)

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

