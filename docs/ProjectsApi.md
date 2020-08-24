# PollinationSDK.Api.ProjectsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateProject**](ProjectsApi.md#createproject) | **POST** /projects/{owner} | Create a Project
[**DeleteProject**](ProjectsApi.md#deleteproject) | **DELETE** /projects/{owner}/{name} | Delete a Project
[**DeleteProjectOrgPermission**](ProjectsApi.md#deleteprojectorgpermission) | **DELETE** /projects/{owner}/{name}/permissions | Remove a Project permissions
[**GetProject**](ProjectsApi.md#getproject) | **GET** /projects/{owner}/{name} | Get a project
[**GetProjectAccessPermissions**](ProjectsApi.md#getprojectaccesspermissions) | **GET** /projects/{owner}/{name}/permissions | Get a project&#39;s access permissions
[**ListProjects**](ProjectsApi.md#listprojects) | **GET** /projects | List Projects
[**Update**](ProjectsApi.md#update) | **PUT** /projects/{owner}/{name} | Update a Project
[**UpsertProjectPermission**](ProjectsApi.md#upsertprojectpermission) | **PATCH** /projects/{owner}/{name}/permissions | Upsert a new permission to a project



## CreateProject

> CreatedContent CreateProject (string owner, PatchProjectDto patchProjectDto)

Create a Project

Create a new project.

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
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var patchProjectDto = new PatchProjectDto(); // PatchProjectDto | 

            try
            {
                // Create a Project
                CreatedContent result = apiInstance.CreateProject(owner, patchProjectDto);
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
 **patchProjectDto** | [**PatchProjectDto**](PatchProjectDto.md)|  | 

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


## DeleteProject

> void DeleteProject (string owner, string name)

Delete a Project

Delete a project (must have `admin` permission)

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
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

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

[Compulsory Auth](../README.md#Compulsory Auth)

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

> void DeleteProjectOrgPermission (string owner, string name, ProjectPolicySubjectDto projectPolicySubjectDto)

Remove a Project permissions

Delete a project's access policy (must have `admin` permission)

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
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectPolicySubjectDto = new ProjectPolicySubjectDto(); // ProjectPolicySubjectDto | 

            try
            {
                // Remove a Project permissions
                apiInstance.DeleteProjectOrgPermission(owner, name, projectPolicySubjectDto);
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
 **projectPolicySubjectDto** | [**ProjectPolicySubjectDto**](ProjectPolicySubjectDto.md)|  | 

### Return type

void (empty response body)

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

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

> ProjectDto GetProject (string owner, string name)

Get a project

Retrieve a project by name

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
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get a project
                ProjectDto result = apiInstance.GetProject(owner, name);
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

[**ProjectDto**](ProjectDto.md)

### Authorization

[Optional Auth](../README.md#Optional Auth)

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

> List&lt;ProjectAccessPolicyDto&gt; GetProjectAccessPermissions (string owner, string name)

Get a project's access permissions

Retrieve a project's access permissions (must have `contribute` permission)

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
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get a project's access permissions
                List<ProjectAccessPolicyDto> result = apiInstance.GetProjectAccessPermissions(owner, name);
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

### Return type

[**List&lt;ProjectAccessPolicyDto&gt;**](ProjectAccessPolicyDto.md)

### Authorization

[Compulsory Auth](../README.md#Compulsory Auth)

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

> List&lt;ProjectDto&gt; ListProjects (int? page = null, int? perPage = null, List<string> id = null, List<string> name = null, List<string> owner = null, bool? _public = null, List<string> _operator = null)

List Projects

search for projects using query parameters

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
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var page = 56;  // int? | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int? | Number of items per page (optional)  (default to 25)
            var id = new List<string>(); // List<string> | The ID of a project to search for (optional) 
            var name = new List<string>(); // List<string> | The account name (optional) 
            var owner = new List<string>(); // List<string> | Owner of the project (optional) 
            var _public = true;  // bool? | Boolean check for public/private projects (optional) 
            var _operator = new List<string>(); // List<string> | Name of an operator to search workflows by (optional) 

            try
            {
                // List Projects
                List<ProjectDto> result = apiInstance.ListProjects(page, perPage, id, name, owner, _public, _operator);
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
 **page** | **int?**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int?**| Number of items per page | [optional] [default to 25]
 **id** | [**List&lt;string&gt;**](string.md)| The ID of a project to search for | [optional] 
 **name** | [**List&lt;string&gt;**](string.md)| The account name | [optional] 
 **owner** | [**List&lt;string&gt;**](string.md)| Owner of the project | [optional] 
 **_public** | **bool?**| Boolean check for public/private projects | [optional] 
 **_operator** | [**List&lt;string&gt;**](string.md)| Name of an operator to search workflows by | [optional] 

### Return type

[**List&lt;ProjectDto&gt;**](ProjectDto.md)

### Authorization

[Optional Auth](../README.md#Optional Auth)

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

> UpdateAccepted Update (string owner, string name, PatchProjectDto patchProjectDto)

Update a Project

Update a project (must have `contribute` permission)

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
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var patchProjectDto = new PatchProjectDto(); // PatchProjectDto | 

            try
            {
                // Update a Project
                UpdateAccepted result = apiInstance.Update(owner, name, patchProjectDto);
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
 **patchProjectDto** | [**PatchProjectDto**](PatchProjectDto.md)|  | 

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

> UpdateAccepted UpsertProjectPermission (string owner, string name, ProjectAccessPolicyDto projectAccessPolicyDto)

Upsert a new permission to a project

Upsert a project's access policy (must have `admin` permission)

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
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new ProjectsApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var projectAccessPolicyDto = new ProjectAccessPolicyDto(); // ProjectAccessPolicyDto | 

            try
            {
                // Upsert a new permission to a project
                UpdateAccepted result = apiInstance.UpsertProjectPermission(owner, name, projectAccessPolicyDto);
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
 **projectAccessPolicyDto** | [**ProjectAccessPolicyDto**](ProjectAccessPolicyDto.md)|  | 

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

