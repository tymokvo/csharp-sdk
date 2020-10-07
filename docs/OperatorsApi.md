# PollinationSDK.Api.OperatorsApi

All URIs are relative to *https://api.pollination.cloud*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateOperator**](OperatorsApi.md#createoperator) | **POST** /operators/{owner} | Create an Operator
[**CreateOperatorPackage**](OperatorsApi.md#createoperatorpackage) | **POST** /operators/{owner}/{name}/tags | Create a new Operator package
[**DeleteOperator**](OperatorsApi.md#deleteoperator) | **DELETE** /operators/{owner}/{name} | Delete an Operator
[**DeleteOperatorOrgPermission**](OperatorsApi.md#deleteoperatororgpermission) | **DELETE** /operators/{owner}/{name}/permissions | Remove a Repository permissions
[**GetOperator**](OperatorsApi.md#getoperator) | **GET** /operators/{owner}/{name} | Get an operator
[**GetOperatorAccessPermissions**](OperatorsApi.md#getoperatoraccesspermissions) | **GET** /operators/{owner}/{name}/permissions | Get operator access permissions
[**GetOperatorByTag**](OperatorsApi.md#getoperatorbytag) | **GET** /operators/{owner}/{name}/tags/{tag} | Get an operator tag
[**ListOperatorTags**](OperatorsApi.md#listoperatortags) | **GET** /operators/{owner}/{name}/tags | Get an operator tags
[**ListOperators**](OperatorsApi.md#listoperators) | **GET** /operators | List operators
[**UpdateOperator**](OperatorsApi.md#updateoperator) | **PUT** /operators/{owner}/{name} | Update an Operator
[**UpsertOperatorPermission**](OperatorsApi.md#upsertoperatorpermission) | **PATCH** /operators/{owner}/{name}/permissions | Upsert a new permission to a operator



## CreateOperator

> CreatedContent CreateOperator (string owner, RepositoryCreate repositoryCreate)

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var repositoryCreate = new RepositoryCreate(); // RepositoryCreate | 

            try
            {
                // Create an Operator
                CreatedContent result = apiInstance.CreateOperator(owner, repositoryCreate);
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
 **repositoryCreate** | [**RepositoryCreate**](RepositoryCreate.md)|  | 

### Return type

[**CreatedContent**](CreatedContent.md)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **202** | Accepted |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## CreateOperatorPackage

> CreatedContent CreateOperatorPackage (string owner, string name, NewOperatorPackage newOperatorPackage)

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var newOperatorPackage = new NewOperatorPackage(); // NewOperatorPackage | 

            try
            {
                // Create a new Operator package
                CreatedContent result = apiInstance.CreateOperatorPackage(owner, name, newOperatorPackage);
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

[**CreatedContent**](CreatedContent.md)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
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

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Accepted |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteOperatorOrgPermission

> void DeleteOperatorOrgPermission (string owner, string name, RepositoryPolicySubject repositoryPolicySubject)

Remove a Repository permissions

Delete a operator's access policy (must have `admin` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteOperatorOrgPermissionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var repositoryPolicySubject = new RepositoryPolicySubject(); // RepositoryPolicySubject | 

            try
            {
                // Remove a Repository permissions
                apiInstance.DeleteOperatorOrgPermission(owner, name, repositoryPolicySubject);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.DeleteOperatorOrgPermission: " + e.Message );
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
 **repositoryPolicySubject** | [**RepositoryPolicySubject**](RepositoryPolicySubject.md)|  | 

### Return type

void (empty response body)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Accepted |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetOperator

> Repository GetOperator (string owner, string name)

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: OptionalAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get an operator
                Repository result = apiInstance.GetOperator(owner, name);
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

[**Repository**](Repository.md)

### Authorization

[OptionalAuth](../README.md#OptionalAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetOperatorAccessPermissions

> RepositoryAccessPolicyList GetOperatorAccessPermissions (string owner, string name, int page = null, int perPage = null, List<string> subjectType = null, List<string> permission = null)

Get operator access permissions

Retrieve a operator's access permissions (must have `contribute` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOperatorAccessPermissionsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var page = 56;  // int | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int | Number of items per page (optional)  (default to 25)
            var subjectType = new List<string>(); // List<string> | The type of access policy subject (optional) 
            var permission = new List<string>(); // List<string> | An access policy permission string (optional) 

            try
            {
                // Get operator access permissions
                RepositoryAccessPolicyList result = apiInstance.GetOperatorAccessPermissions(owner, name, page, perPage, subjectType, permission);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.GetOperatorAccessPermissions: " + e.Message );
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
 **page** | **int**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int**| Number of items per page | [optional] [default to 25]
 **subjectType** | [**List&lt;string&gt;**](string.md)| The type of access policy subject | [optional] 
 **permission** | [**List&lt;string&gt;**](string.md)| An access policy permission string | [optional] 

### Return type

[**RepositoryAccessPolicyList**](RepositoryAccessPolicyList.md)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: OptionalAuth
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

[OptionalAuth](../README.md#OptionalAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListOperatorTags

> RepositoryPackageList ListOperatorTags (string owner, string name)

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: OptionalAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get an operator tags
                RepositoryPackageList result = apiInstance.ListOperatorTags(owner, name);
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

[**RepositoryPackageList**](RepositoryPackageList.md)

### Authorization

[OptionalAuth](../README.md#OptionalAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retrieved |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListOperators

> RepositoryList ListOperators (int page = null, int perPage = null, List<string> name = null, List<string> owner = null, bool _public = null, List<string> keyword = null, List<string> permission = null)

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: OptionalAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var page = 56;  // int | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int | Number of items per page (optional)  (default to 25)
            var name = new List<string>(); // List<string> | The account name (optional) 
            var owner = new List<string>(); // List<string> | Owner of the project (optional) 
            var _public = true;  // bool | Boolean check for public/private projects (optional) 
            var keyword = new List<string>(); // List<string> | A keyword to index the repository by (optional) 
            var permission = new List<string>(); // List<string> |  (optional) 

            try
            {
                // List operators
                RepositoryList result = apiInstance.ListOperators(page, perPage, name, owner, _public, keyword, permission);
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
 **permission** | [**List&lt;string&gt;**](string.md)|  | [optional] 

### Return type

[**RepositoryList**](RepositoryList.md)

### Authorization

[OptionalAuth](../README.md#OptionalAuth)

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

> UpdateAccepted UpdateOperator (string owner, string name, RepositoryUpdate repositoryUpdate)

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
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var repositoryUpdate = new RepositoryUpdate(); // RepositoryUpdate | 

            try
            {
                // Update an Operator
                UpdateAccepted result = apiInstance.UpdateOperator(owner, name, repositoryUpdate);
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
 **repositoryUpdate** | [**RepositoryUpdate**](RepositoryUpdate.md)|  | 

### Return type

[**UpdateAccepted**](UpdateAccepted.md)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertOperatorPermission

> UpdateAccepted UpsertOperatorPermission (string owner, string name, RepositoryAccessPolicy repositoryAccessPolicy)

Upsert a new permission to a operator

Upsert a operator's access policy (must have `admin` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpsertOperatorPermissionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OperatorsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var repositoryAccessPolicy = new RepositoryAccessPolicy(); // RepositoryAccessPolicy | 

            try
            {
                // Upsert a new permission to a operator
                UpdateAccepted result = apiInstance.UpsertOperatorPermission(owner, name, repositoryAccessPolicy);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OperatorsApi.UpsertOperatorPermission: " + e.Message );
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
 **repositoryAccessPolicy** | [**RepositoryAccessPolicy**](RepositoryAccessPolicy.md)|  | 

### Return type

[**UpdateAccepted**](UpdateAccepted.md)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **400** | Invalid request |  -  |
| **403** | Access forbidden |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

