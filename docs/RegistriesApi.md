# PollinationSDK.Api.RegistriesApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetPackage**](RegistriesApi.md#getpackage) | **GET** /registries/{owner}/{type}/{name}/{digest} | Get Package
[**GetRegistryIndex**](RegistriesApi.md#getregistryindex) | **GET** /registries/{owner}/index.json | Get Registry Index
[**PostOperator**](RegistriesApi.md#postoperator) | **POST** /registries/{owner}/operators | Push an Operator to the registry
[**PostRecipe**](RegistriesApi.md#postrecipe) | **POST** /registries/{owner}/recipes | Push an Recipe to the registry



## GetPackage

> void GetPackage (string owner, string type, string name, string digest)

Get Package

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetPackageExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RegistriesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var type = type_example;  // string | 
            var name = name_example;  // string | 
            var digest = digest_example;  // string | 

            try
            {
                // Get Package
                apiInstance.GetPackage(owner, type, name, digest);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RegistriesApi.GetPackage: " + e.Message );
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
 **type** | **string**|  | 
 **name** | **string**|  | 
 **digest** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[Optional Auth](../README.md#Optional Auth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/x-tar, application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRegistryIndex

> RepositoryIndex GetRegistryIndex (string owner)

Get Registry Index

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRegistryIndexExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RegistriesApi(Configuration.Default);
            var owner = owner_example;  // string | 

            try
            {
                // Get Registry Index
                RepositoryIndex result = apiInstance.GetRegistryIndex(owner);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RegistriesApi.GetRegistryIndex: " + e.Message );
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

### Return type

[**RepositoryIndex**](RepositoryIndex.md)

### Authorization

[Optional Auth](../README.md#Optional Auth)

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


## PostOperator

> Object PostOperator (string owner, System.IO.Stream package)

Push an Operator to the registry

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class PostOperatorExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RegistriesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var package = BINARY_DATA_HERE;  // System.IO.Stream | 

            try
            {
                // Push an Operator to the registry
                Object result = apiInstance.PostOperator(owner, package);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RegistriesApi.PostOperator: " + e.Message );
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
 **package** | **System.IO.Stream**|  | 

### Return type

**Object**

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

### HTTP request headers

- **Content-Type**: multipart/form-data
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## PostRecipe

> Object PostRecipe (string owner, System.IO.Stream package, string authorization = null)

Push an Recipe to the registry

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class PostRecipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RegistriesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var package = BINARY_DATA_HERE;  // System.IO.Stream | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                // Push an Recipe to the registry
                Object result = apiInstance.PostRecipe(owner, package, authorization);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RegistriesApi.PostRecipe: " + e.Message );
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
 **package** | **System.IO.Stream**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

**Object**

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

### HTTP request headers

- **Content-Type**: multipart/form-data
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

