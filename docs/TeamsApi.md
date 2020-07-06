# PollinationSDK.Api.TeamsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateTeam**](TeamsApi.md#createteam) | **POST** /orgs/{org_name}/teams | Create a Team
[**DeleteOrgTeamMember**](TeamsApi.md#deleteorgteammember) | **DELETE** /orgs/{org_name}/teams/{team_slug}/members/{username} | Remove a team member
[**DeleteTeam**](TeamsApi.md#deleteteam) | **DELETE** /orgs/{org_name}/teams/{team_slug} | Delete a Team
[**GetOrgTeamMembers**](TeamsApi.md#getorgteammembers) | **GET** /orgs/{org_name}/teams/{team_slug}/members | List a team&#39;s members
[**GetTeam**](TeamsApi.md#getteam) | **GET** /orgs/{org_name}/teams/{team_slug} | Get a Team
[**ListOrgTeams**](TeamsApi.md#listorgteams) | **GET** /orgs/{org_name}/teams | List Teams
[**UpdateTeam**](TeamsApi.md#updateteam) | **PUT** /orgs/{org_name}/teams/{team_slug} | Update a Team
[**UpsertOrgTeamMember**](TeamsApi.md#upsertorgteammember) | **PATCH** /orgs/{org_name}/teams/{team_slug}/members/{username}/{role} | Add or update the role of an Org Member



## CreateTeam

> CreatedContent CreateTeam (string orgName, PatchTeamDto patchTeamDto)

Create a Team

Create a new team (must be parent org member)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateTeamExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var patchTeamDto = new PatchTeamDto(); // PatchTeamDto | 

            try
            {
                // Create a Team
                CreatedContent result = apiInstance.CreateTeam(orgName, patchTeamDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.CreateTeam: " + e.Message );
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
 **orgName** | **string**|  | 
 **patchTeamDto** | [**PatchTeamDto**](PatchTeamDto.md)|  | 

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


## DeleteOrgTeamMember

> void DeleteOrgTeamMember (string orgName, string teamSlug, string username)

Remove a team member

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
    public class DeleteOrgTeamMemberExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var teamSlug = teamSlug_example;  // string | 
            var username = username_example;  // string | 

            try
            {
                // Remove a team member
                apiInstance.DeleteOrgTeamMember(orgName, teamSlug, username);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.DeleteOrgTeamMember: " + e.Message );
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
 **orgName** | **string**|  | 
 **teamSlug** | **string**|  | 
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


## DeleteTeam

> void DeleteTeam (string orgName, string teamSlug)

Delete a Team

Delete a team (must have team or org `owner` role)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteTeamExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var teamSlug = teamSlug_example;  // string | 

            try
            {
                // Delete a Team
                apiInstance.DeleteTeam(orgName, teamSlug);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.DeleteTeam: " + e.Message );
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
 **orgName** | **string**|  | 
 **teamSlug** | **string**|  | 

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


## GetOrgTeamMembers

> List&lt;TeamMemberDto&gt; GetOrgTeamMembers (string orgName, string teamSlug)

List a team's members

Retrieve a tean's members

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetOrgTeamMembersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var teamSlug = teamSlug_example;  // string | 

            try
            {
                // List a team's members
                List<TeamMemberDto> result = apiInstance.GetOrgTeamMembers(orgName, teamSlug);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.GetOrgTeamMembers: " + e.Message );
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
 **orgName** | **string**|  | 
 **teamSlug** | **string**|  | 

### Return type

[**List&lt;TeamMemberDto&gt;**](TeamMemberDto.md)

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


## GetTeam

> TeamDto GetTeam (string orgName, string teamSlug)

Get a Team

Retrieve a team by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetTeamExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var teamSlug = teamSlug_example;  // string | 

            try
            {
                // Get a Team
                TeamDto result = apiInstance.GetTeam(orgName, teamSlug);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.GetTeam: " + e.Message );
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
 **orgName** | **string**|  | 
 **teamSlug** | **string**|  | 

### Return type

[**TeamDto**](TeamDto.md)

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


## ListOrgTeams

> List&lt;TeamDto&gt; ListOrgTeams (string orgName, int page = null, int perPage = null, List<string> name = null, List<string> member = null)

List Teams

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
    public class ListOrgTeamsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var page = 56;  // int | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int | Number of items per page (optional)  (default to 25)
            var name = new List<string>(); // List<string> | The account name (optional) 
            var member = new List<string>(); // List<string> | The ID of a user (optional) 

            try
            {
                // List Teams
                List<TeamDto> result = apiInstance.ListOrgTeams(orgName, page, perPage, name, member);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.ListOrgTeams: " + e.Message );
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
 **orgName** | **string**|  | 
 **page** | **int**| Page number starting from 1 | [optional] [default to 1]
 **perPage** | **int**| Number of items per page | [optional] [default to 25]
 **name** | [**List&lt;string&gt;**](string.md)| The account name | [optional] 
 **member** | [**List&lt;string&gt;**](string.md)| The ID of a user | [optional] 

### Return type

[**List&lt;TeamDto&gt;**](TeamDto.md)

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


## UpdateTeam

> UpdateAccepted UpdateTeam (string orgName, string teamSlug, PatchTeamDto patchTeamDto)

Update a Team

Update a team (must have team or org `owner` role)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpdateTeamExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var teamSlug = teamSlug_example;  // string | 
            var patchTeamDto = new PatchTeamDto(); // PatchTeamDto | 

            try
            {
                // Update a Team
                UpdateAccepted result = apiInstance.UpdateTeam(orgName, teamSlug, patchTeamDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.UpdateTeam: " + e.Message );
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
 **orgName** | **string**|  | 
 **teamSlug** | **string**|  | 
 **patchTeamDto** | [**PatchTeamDto**](PatchTeamDto.md)|  | 

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


## UpsertOrgTeamMember

> UpdateAccepted UpsertOrgTeamMember (string orgName, string teamSlug, string username, string role)

Add or update the role of an Org Member

Upsert a member role to the team (must have org or team `owner` role)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpsertOrgTeamMemberExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new TeamsApi(Configuration.Default);
            var orgName = orgName_example;  // string | 
            var teamSlug = teamSlug_example;  // string | 
            var username = username_example;  // string | 
            var role = role_example;  // string | 

            try
            {
                // Add or update the role of an Org Member
                UpdateAccepted result = apiInstance.UpsertOrgTeamMember(orgName, teamSlug, username, role);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TeamsApi.UpsertOrgTeamMember: " + e.Message );
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
 **orgName** | **string**|  | 
 **teamSlug** | **string**|  | 
 **username** | **string**|  | 
 **role** | **string**|  | 

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

