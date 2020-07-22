# PollinationSDK.Api.OrgsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateOrg**](OrgsApi.md#createorg) | **POST** /orgs | Create an Org
[**DeleteOrg**](OrgsApi.md#deleteorg) | **DELETE** /orgs/{name} | Delete an Org
[**DeleteOrgMember**](OrgsApi.md#deleteorgmember) | **DELETE** /orgs/{name}/members/{username} | Remove an Org member
[**GetOrg**](OrgsApi.md#getorg) | **GET** /orgs/{name} | Get an Org
[**GetOrgMembers**](OrgsApi.md#getorgmembers) | **GET** /orgs/{name}/members | List an Org&#39;s members
[**ListOrgs**](OrgsApi.md#listorgs) | **GET** /orgs | List Orgs
[**UpdateOrg**](OrgsApi.md#updateorg) | **PUT** /orgs/{name} | Update an Org
[**UpsertOrgMember**](OrgsApi.md#upsertorgmember) | **PATCH** /orgs/{name}/members/{username}/{role} | Add or update the role of an Org Member



## CreateOrg

> CreatedContent CreateOrg (CreateOrgDto createOrgDto)

Create an Org

Create a new org.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateOrgExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OrgsApi(Configuration.Default);
            var createOrgDto = new CreateOrgDto(); // CreateOrgDto | 

            try
            {
                // Create an Org
                CreatedContent result = apiInstance.CreateOrg(createOrgDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.CreateOrg: " + e.Message );
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
 **createOrgDto** | [**CreateOrgDto**](CreateOrgDto.md)|  | 

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


## DeleteOrg

> void DeleteOrg (string name)

Delete an Org

Delete a org (must have `admin` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteOrgExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OrgsApi(Configuration.Default);
            var name = name_example;  // string | 

            try
            {
                // Delete an Org
                apiInstance.DeleteOrg(name);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.DeleteOrg: " + e.Message );
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


## DeleteOrgMember

> void DeleteOrgMember (string name, string username)

Remove an Org member

Remove a member from the org (must have org `owner` role)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteOrgMemberExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OrgsApi(Configuration.Default);
            var name = name_example;  // string | 
            var username = username_example;  // string | 

            try
            {
                // Remove an Org member
                apiInstance.DeleteOrgMember(name, username);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.DeleteOrgMember: " + e.Message );
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
 **username** | **string**|  | 

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


## GetOrg

> OrgDto GetOrg (string name)

Get an Org

Retrieve a org by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOrgExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new OrgsApi(Configuration.Default);
            var name = name_example;  // string | 

            try
            {
                // Get an Org
                OrgDto result = apiInstance.GetOrg(name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.GetOrg: " + e.Message );
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

[**OrgDto**](OrgDto.md)

### Authorization

No authorization required

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


## GetOrgMembers

> List&lt;OrgMemberDto&gt; GetOrgMembers (string name)

List an Org's members

Retrieve a org's members

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOrgMembersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new OrgsApi(Configuration.Default);
            var name = name_example;  // string | 

            try
            {
                // List an Org's members
                List<OrgMemberDto> result = apiInstance.GetOrgMembers(name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.GetOrgMembers: " + e.Message );
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

[**List&lt;OrgMemberDto&gt;**](OrgMemberDto.md)

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


## ListOrgs

> List&lt;OrgDto&gt; ListOrgs (int page = null, int perPage = null, List<string> name = null, List<string> member = null)

List Orgs

search for orgs using query parameters

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListOrgsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new OrgsApi(Configuration.Default);
            var page = 56;  // int | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int | Number of items per page (optional)  (default to 25)
            var name = new List<string>(); // List<string> | The account name (optional) 
            var member = new List<string>(); // List<string> | The ID of a user (optional) 

            try
            {
                // List Orgs
                List<OrgDto> result = apiInstance.ListOrgs(page, perPage, name, member);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.ListOrgs: " + e.Message );
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
 **member** | [**List&lt;string&gt;**](string.md)| The ID of a user | [optional] 

### Return type

[**List&lt;OrgDto&gt;**](OrgDto.md)

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


## UpdateOrg

> UpdateAccepted UpdateOrg (string name, PatchOrgDto patchOrgDto)

Update an Org

Update a org (must have org `owner` role)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpdateOrgExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OrgsApi(Configuration.Default);
            var name = name_example;  // string | 
            var patchOrgDto = new PatchOrgDto(); // PatchOrgDto | 

            try
            {
                // Update an Org
                UpdateAccepted result = apiInstance.UpdateOrg(name, patchOrgDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.UpdateOrg: " + e.Message );
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
 **patchOrgDto** | [**PatchOrgDto**](PatchOrgDto.md)|  | 

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


## UpsertOrgMember

> UpdateAccepted UpsertOrgMember (string name, string username, OrgRoleEnum role)

Add or update the role of an Org Member

Upsert a member role to the org (must have org `owner` role)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpsertOrgMemberExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new OrgsApi(Configuration.Default);
            var name = name_example;  // string | 
            var username = username_example;  // string | 
            var role = new OrgRoleEnum(); // OrgRoleEnum | 

            try
            {
                // Add or update the role of an Org Member
                UpdateAccepted result = apiInstance.UpsertOrgMember(name, username, role);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrgsApi.UpsertOrgMember: " + e.Message );
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
 **username** | **string**|  | 
 **role** | [**OrgRoleEnum**](OrgRoleEnum.md)|  | 

### Return type

[**UpdateAccepted**](UpdateAccepted.md)

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
| **202** | Success |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

