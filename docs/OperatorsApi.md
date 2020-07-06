# PollinationSDK.Api.OperatorsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateOperator**](OperatorsApi.md#createoperator) | **POST** /operators/{owner} | Create an Operator
[**CreateOperatorPackage**](OperatorsApi.md#createoperatorpackage) | **POST** /operators/{owner}/{name}/tags | Create a new Operator package
[**DeleteOperator**](OperatorsApi.md#deleteoperator) | **DELETE** /operators/{owner}/{name} | Delete an Operator
[**GetOperator**](OperatorsApi.md#getoperator) | **GET** /operators/{owner}/{name} | Get an operator
[**GetOperatorByTag**](OperatorsApi.md#getoperatorbytag) | **GET** /operators/{owner}/{name}/tags/{tag} | Get an operator tag
[**ListOperatorTags**](OperatorsApi.md#listoperatortags) | **GET** /operators/{owner}/{name}/tags | Get an operator tags
[**ListOperators**](OperatorsApi.md#listoperators) | **GET** /operators | List operators
[**UpdateOperator**](OperatorsApi.md#updateoperator) | **PUT** /operators/{owner}/{name} | Update an Operator



## CreateOperator

> CreatedContent CreateOperator (string owner, NewRepositoryDto newRepositoryDto)

Create an Operator

Create a new operator.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateOperatorExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var newRepositoryDto = new NewRepositoryDto(); // NewRepositoryDto | 

            try
            {
                // Create an Operator
                CreatedContent result = apiInstance.CreateOperator(owner, newRepositoryDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.CreateOperator: " + e.Message );
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
 **newRepositoryDto** | [**NewRepositoryDto**](NewRepositoryDto.md)|  | 

### Return type

[**CreatedContent**](CreatedContent.md)

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **202** | Success |  -  |
| **201** | Success |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## CreateOperatorPackage

> PackageDto CreateOperatorPackage (string owner, string name, NewOperatorPackage newOperatorPackage)

Create a new Operator package

Create a new operator package version

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateOperatorPackageExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var newOperatorPackage = new NewOperatorPackage(); // NewOperatorPackage | 

            try
            {
                // Create a new Operator package
                PackageDto result = apiInstance.CreateOperatorPackage(owner, name, newOperatorPackage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.CreateOperatorPackage: " + e.Message );
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
 **newOperatorPackage** | [**NewOperatorPackage**](NewOperatorPackage.md)|  | 

### Return type

[**PackageDto**](PackageDto.md)

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **200** | Success |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteOperator

> void DeleteOperator (string owner, string name)

Delete an Operator

Delete an operator (must have `admin` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteOperatorExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Delete an Operator
                apiInstance.DeleteOperator(owner, name);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.DeleteOperator: " + e.Message );
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

### Return type

void (empty response body)

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **204** | Success |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetOperator

> RepositoryDto GetOperator (string owner, string name)

Get an operator

Retrieve an operator by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOperatorExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get an operator
                RepositoryDto result = apiInstance.GetOperator(owner, name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.GetOperator: " + e.Message );
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

### Return type

[**RepositoryDto**](RepositoryDto.md)

### Authorization

[Optional Auth](../README.md#Optional Auth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **200** | Retrieved |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetOperatorByTag

> OperatorPackage GetOperatorByTag (string owner, string name, string tag)

Get an operator tag

Retrieve an operator tag by name and tag

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOperatorByTagExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var tag = tag_example;  // string | 

            try
            {
                // Get an operator tag
                OperatorPackage result = apiInstance.GetOperatorByTag(owner, name, tag);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.GetOperatorByTag: " + e.Message );
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
 **tag** | **string**|  | 

### Return type

[**OperatorPackage**](OperatorPackage.md)

### Authorization

[Optional Auth](../README.md#Optional Auth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **200** | Retrieved |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListOperatorTags

> PackageListDto ListOperatorTags (string owner, string name)

Get an operator tags

Retrieve an operator by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListOperatorTagsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get an operator tags
                PackageListDto result = apiInstance.ListOperatorTags(owner, name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.ListOperatorTags: " + e.Message );
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

### Return type

[**PackageListDto**](PackageListDto.md)

### Authorization

[Optional Auth](../README.md#Optional Auth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **200** | Retrieved |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListOperators

> RepositoryListDto ListOperators (int page = null, int perPage = null, List<string> name = null, List<string> owner = null, bool _public = null, List<string> keyword = null)

List operators

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListOperatorsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var page = 56;  // int | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int | Number of items per page (optional)  (default to 25)
            var name = new List<string>(); // List<string> | The account name (optional) 
            var owner = new List<string>(); // List<string> | Owner of the project (optional) 
            var _public = true;  // bool | Boolean check for public/private projects (optional) 
            var keyword = new List<string>(); // List<string> | A keyword to index the repository by (optional) 

            try
            {
                // List operators
                RepositoryListDto result = apiInstance.ListOperators(page, perPage, name, owner, _public, keyword);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.ListOperators: " + e.Message );
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
 **page** | **int**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int**| Number of items per page | [optional] [default to 25]
 **name** | [**List&lt;string&gt;**](string.md)| The account name | [optional] 
 **owner** | [**List&lt;string&gt;**](string.md)| Owner of the project | [optional] 
 **_public** | **bool**| Boolean check for public/private projects | [optional] 
 **keyword** | [**List&lt;string&gt;**](string.md)| A keyword to index the repository by | [optional] 

### Return type

[**RepositoryListDto**](RepositoryListDto.md)

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


## UpdateOperator

> UpdateAccepted UpdateOperator (string owner, string name, UpdateRepositoryDto updateRepositoryDto)

Update an Operator

Update an operator (must have `contribute` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpdateOperatorExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var updateRepositoryDto = new UpdateRepositoryDto(); // UpdateRepositoryDto | 

            try
            {
                // Update an Operator
                UpdateAccepted result = apiInstance.UpdateOperator(owner, name, updateRepositoryDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.UpdateOperator: " + e.Message );
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
 **updateRepositoryDto** | [**UpdateRepositoryDto**](UpdateRepositoryDto.md)|  | 

### Return type

[**UpdateAccepted**](UpdateAccepted.md)

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **202** | Success |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

