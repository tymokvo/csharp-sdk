# PollinationSDK.Api.ProjectsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateProject**](ProjectsApi.md#createproject) | **POST** /projects/{owner} | Create a Project
[**CreateProjectRecipeFilter**](ProjectsApi.md#createprojectrecipefilter) | **POST** /projects/{owner}/{name}/recipes/filters | Upsert a recipe filter to a project
[**DeleteProject**](ProjectsApi.md#deleteproject) | **DELETE** /projects/{owner}/{name} | Delete a Project
[**DeleteProjectOrgPermission**](ProjectsApi.md#deleteprojectorgpermission) | **DELETE** /projects/{owner}/{name}/permissions | Remove a Project permissions
[**DeleteProjectRecipeFilter**](ProjectsApi.md#deleteprojectrecipefilter) | **DELETE** /projects/{owner}/{name}/recipes/filters | Remove a Project recipe filter
[**GetProject**](ProjectsApi.md#getproject) | **GET** /projects/{owner}/{name} | Get a project
[**GetProjectAccessPermissions**](ProjectsApi.md#getprojectaccesspermissions) | **GET** /projects/{owner}/{name}/permissions | Get project access permissions
[**GetProjectRecipeFilters**](ProjectsApi.md#getprojectrecipefilters) | **GET** /projects/{owner}/{name}/recipes/filters | Get project recipe filters
[**GetProjectRecipes**](ProjectsApi.md#getprojectrecipes) | **GET** /projects/{owner}/{name}/recipes | Get project recipes
[**ListProjects**](ProjectsApi.md#listprojects) | **GET** /projects | List Projects
[**Update**](ProjectsApi.md#update) | **PUT** /projects/{owner}/{name} | Update a Project
[**UpsertProjectPermission**](ProjectsApi.md#upsertprojectpermission) | **PATCH** /projects/{owner}/{name}/permissions | Upsert a new permission to a project



## CreateProject

> CreatedContent CreateProject (string owner, ProjectCreate projectCreate)

Create a Project

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateProjectExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var projectCreate = new ProjectCreate(); // ProjectCreate | 

            try
            {
                // Create a Project
                CreatedContent result = apiInstance.CreateProject(owner, projectCreate);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.CreateProject: " + e.Message );
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
 **projectCreate** | [**ProjectCreate**](ProjectCreate.md)|  | 

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
| **201** | Success |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **202** | Accepted |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## CreateProjectRecipeFilter

> ProjectRecipeFilter CreateProjectRecipeFilter (string owner, string name, ProjectRecipeFilter projectRecipeFilter)

Upsert a recipe filter to a project

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateProjectRecipeFilterExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectRecipeFilter = new ProjectRecipeFilter(); // ProjectRecipeFilter | 

            try
            {
                // Upsert a recipe filter to a project
                ProjectRecipeFilter result = apiInstance.CreateProjectRecipeFilter(owner, name, projectRecipeFilter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.CreateProjectRecipeFilter: " + e.Message );
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
 **projectRecipeFilter** | [**ProjectRecipeFilter**](ProjectRecipeFilter.md)|  | 

### Return type

[**ProjectRecipeFilter**](ProjectRecipeFilter.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteProject

> void DeleteProject (string owner, string name)

Delete a Project

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteProjectExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Delete a Project
                apiInstance.DeleteProject(owner, name);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.DeleteProject: " + e.Message );
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

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Accepted |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteProjectOrgPermission

> void DeleteProjectOrgPermission (string owner, string name, ProjectPolicySubject projectPolicySubject)

Remove a Project permissions

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteProjectOrgPermissionExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectPolicySubject = new ProjectPolicySubject(); // ProjectPolicySubject | 

            try
            {
                // Remove a Project permissions
                apiInstance.DeleteProjectOrgPermission(owner, name, projectPolicySubject);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.DeleteProjectOrgPermission: " + e.Message );
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
 **projectPolicySubject** | [**ProjectPolicySubject**](ProjectPolicySubject.md)|  | 

### Return type

void (empty response body)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Accepted |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteProjectRecipeFilter

> void DeleteProjectRecipeFilter (string owner, string name, ProjectRecipeFilter projectRecipeFilter)

Remove a Project recipe filter

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteProjectRecipeFilterExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectRecipeFilter = new ProjectRecipeFilter(); // ProjectRecipeFilter | 

            try
            {
                // Remove a Project recipe filter
                apiInstance.DeleteProjectRecipeFilter(owner, name, projectRecipeFilter);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.DeleteProjectRecipeFilter: " + e.Message );
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
 **projectRecipeFilter** | [**ProjectRecipeFilter**](ProjectRecipeFilter.md)|  | 

### Return type

void (empty response body)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Accepted |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetProject

> Project GetProject (string owner, string name)

Get a project

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetProjectExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get a project
                Project result = apiInstance.GetProject(owner, name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetProject: " + e.Message );
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

[**Project**](Project.md)

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


## GetProjectAccessPermissions

> ProjectAccessPolicyList GetProjectAccessPermissions (string owner, string name, int? page = null, int? perPage = null, List<string> subjectType = null, List<string> permission = null)

Get project access permissions

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetProjectAccessPermissionsExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)
            var subjectType = new List<string>(); // List<string> | The type of access policy subject (optional) 
            var permission = new List<string>(); // List<string> | An access policy permission string (optional) 

            try
            {
                // Get project access permissions
                ProjectAccessPolicyList result = apiInstance.GetProjectAccessPermissions(owner, name, page, perPage, subjectType, permission);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetProjectAccessPermissions: " + e.Message );
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
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]
 **subjectType** | [**List&lt;string&gt;**](string.md)| The type of access policy subject | [optional] 
 **permission** | [**List&lt;string&gt;**](string.md)| An access policy permission string | [optional] 

### Return type

[**ProjectAccessPolicyList**](ProjectAccessPolicyList.md)

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
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetProjectRecipeFilters

> ProjectRecipeFilterList GetProjectRecipeFilters (string owner, string name, int? page = null, int? perPage = null)

Get project recipe filters

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetProjectRecipeFiltersExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // Get project recipe filters
                ProjectRecipeFilterList result = apiInstance.GetProjectRecipeFilters(owner, name, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetProjectRecipeFilters: " + e.Message );
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
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**ProjectRecipeFilterList**](ProjectRecipeFilterList.md)

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
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetProjectRecipes

> RecipeInterfaceList GetProjectRecipes (string owner, string name, string search = null, int? page = null, int? perPage = null)

Get project recipes

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetProjectRecipesExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var search = search_example;  // string | Search string to find recipes (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // Get project recipes
                RecipeInterfaceList result = apiInstance.GetProjectRecipes(owner, name, search, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetProjectRecipes: " + e.Message );
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
 **search** | **string**| Search string to find recipes | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**RecipeInterfaceList**](RecipeInterfaceList.md)

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
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListProjects

> ProjectList ListProjects (string search = null, List<string> ids = null, List<string> names = null, List<string> owner = null, bool? _public = null, List<string> permissions = null, ProjectSortKey sortBy = null, SortEnum? sortOrder = null, int? page = null, int? perPage = null)

List Projects

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListProjectsExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var search = search_example;  // string | Search string to find projects (optional) 
            var ids = new List<string>(); // List<string> | The ID of a project to search for (optional) 
            var names = new List<string>(); // List<string> | The name of the project (optional) 
            var owner = new List<string>(); // List<string> | Owner of the project (optional) 
            var _public = true;  // bool? | Boolean check for public/private projects (optional) 
            var permissions = new List<string>(); // List<string> | Filter by permission on given resource (optional) 
            var sortBy = new ProjectSortKey(); // ProjectSortKey | Key to sort the list by (optional) 
            var sortOrder = ;  // SortEnum? | The order to sort the list (optional) 
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)

            try
            {
                // List Projects
                ProjectList result = apiInstance.ListProjects(search, ids, names, owner, _public, permissions, sortBy, sortOrder, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.ListProjects: " + e.Message );
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
 **search** | **string**| Search string to find projects | [optional] 
 **ids** | [**List&lt;string&gt;**](string.md)| The ID of a project to search for | [optional] 
 **names** | [**List&lt;string&gt;**](string.md)| The name of the project | [optional] 
 **owner** | [**List&lt;string&gt;**](string.md)| Owner of the project | [optional] 
 **_public** | **bool?**| Boolean check for public/private projects | [optional] 
 **permissions** | [**List&lt;string&gt;**](string.md)| Filter by permission on given resource | [optional] 
 **sortBy** | [**ProjectSortKey**](ProjectSortKey.md)| Key to sort the list by | [optional] 
 **sortOrder** | **SortEnum?**| The order to sort the list | [optional] 
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]

### Return type

[**ProjectList**](ProjectList.md)

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
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Update

> UpdateAccepted Update (string owner, string name, ProjectUpdate projectUpdate)

Update a Project

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpdateExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectUpdate = new ProjectUpdate(); // ProjectUpdate | 

            try
            {
                // Update a Project
                UpdateAccepted result = apiInstance.Update(owner, name, projectUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.Update: " + e.Message );
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
 **projectUpdate** | [**ProjectUpdate**](ProjectUpdate.md)|  | 

### Return type

[**UpdateAccepted**](UpdateAccepted.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertProjectPermission

> UpdateAccepted UpsertProjectPermission (string owner, string name, ProjectAccessPolicy projectAccessPolicy)

Upsert a new permission to a project

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpsertProjectPermissionExample
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

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectAccessPolicy = new ProjectAccessPolicy(); // ProjectAccessPolicy | 

            try
            {
                // Upsert a new permission to a project
                UpdateAccepted result = apiInstance.UpsertProjectPermission(owner, name, projectAccessPolicy);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ProjectsApi.UpsertProjectPermission: " + e.Message );
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
 **projectAccessPolicy** | [**ProjectAccessPolicy**](ProjectAccessPolicy.md)|  | 

### Return type

[**UpdateAccepted**](UpdateAccepted.md)

### Authorization

[APIKeyAuth](../README.md#APIKeyAuth), [JWTAuth](../README.md#JWTAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

