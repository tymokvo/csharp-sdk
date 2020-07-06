# PollinationSDK.Api.RecipesApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRecipe**](RecipesApi.md#createrecipe) | **POST** /recipes/{owner} | Create a Recipe
[**CreateRecipePackage**](RecipesApi.md#createrecipepackage) | **POST** /recipes/{owner}/{name}/tags | Create a new Recipe package
[**DeleteRecipe**](RecipesApi.md#deleterecipe) | **DELETE** /recipes/{owner}/{name} | Delete a Recipe
[**GetRecipe**](RecipesApi.md#getrecipe) | **GET** /recipes/{owner}/{name} | Get a recipe
[**GetRecipeByTag**](RecipesApi.md#getrecipebytag) | **GET** /recipes/{owner}/{name}/tags/{tag} | Get a recipe tag
[**ListRecipeTags**](RecipesApi.md#listrecipetags) | **GET** /recipes/{owner}/{name}/tags | Get a recipe tags
[**ListRecipes**](RecipesApi.md#listrecipes) | **GET** /recipes | List recipes
[**UpdateRecipe**](RecipesApi.md#updaterecipe) | **PUT** /recipes/{owner}/{name} | Update a Recipe



## CreateRecipe

> CreatedContent CreateRecipe (string owner, NewRepositoryDto newRepositoryDto)

Create a Recipe

Create a new recipe.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateRecipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var newRepositoryDto = new NewRepositoryDto(); // NewRepositoryDto | 

            try
            {
                // Create a Recipe
                CreatedContent result = apiInstance.CreateRecipe(owner, newRepositoryDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.CreateRecipe: " + e.Message );
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


## CreateRecipePackage

> PackageDto CreateRecipePackage (string owner, string name, NewRecipePackage newRecipePackage, string authorization = null)

Create a new Recipe package

Create a new recipe package version

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class CreateRecipePackageExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var newRecipePackage = new NewRecipePackage(); // NewRecipePackage | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                // Create a new Recipe package
                PackageDto result = apiInstance.CreateRecipePackage(owner, name, newRecipePackage, authorization);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.CreateRecipePackage: " + e.Message );
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
 **newRecipePackage** | [**NewRecipePackage**](NewRecipePackage.md)|  | 
 **authorization** | **string**|  | [optional] 

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


## DeleteRecipe

> void DeleteRecipe (string owner, string name)

Delete a Recipe

Delete a recipe (must have `admin` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class DeleteRecipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Delete a Recipe
                apiInstance.DeleteRecipe(owner, name);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.DeleteRecipe: " + e.Message );
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


## GetRecipe

> RepositoryDto GetRecipe (string owner, string name)

Get a recipe

Retrieve a recipe by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRecipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get a recipe
                RepositoryDto result = apiInstance.GetRecipe(owner, name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.GetRecipe: " + e.Message );
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


## GetRecipeByTag

> RecipePackage GetRecipeByTag (string owner, string name, string tag)

Get a recipe tag

Retrieve a recipe tag by name and tag

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRecipeByTagExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var tag = tag_example;  // string | 

            try
            {
                // Get a recipe tag
                RecipePackage result = apiInstance.GetRecipeByTag(owner, name, tag);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.GetRecipeByTag: " + e.Message );
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

[**RecipePackage**](RecipePackage.md)

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


## ListRecipeTags

> PackageListDto ListRecipeTags (string owner, string name)

Get a recipe tags

Retrieve a recipe by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListRecipeTagsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 

            try
            {
                // Get a recipe tags
                PackageListDto result = apiInstance.ListRecipeTags(owner, name);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.ListRecipeTags: " + e.Message );
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


## ListRecipes

> RepositoryListDto ListRecipes (int page = null, int perPage = null, List<string> name = null, List<string> owner = null, bool _public = null, List<string> keyword = null)

List recipes

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListRecipesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Optional Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var page = 56;  // int | Page number starting from 1 (optional)  (default to 1)
            var perPage = 56;  // int | Number of items per page (optional)  (default to 25)
            var name = new List<string>(); // List<string> | The account name (optional) 
            var owner = new List<string>(); // List<string> | Owner of the project (optional) 
            var _public = true;  // bool | Boolean check for public/private projects (optional) 
            var keyword = new List<string>(); // List<string> | A keyword to index the repository by (optional) 

            try
            {
                // List recipes
                RepositoryListDto result = apiInstance.ListRecipes(page, perPage, name, owner, _public, keyword);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.ListRecipes: " + e.Message );
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


## UpdateRecipe

> UpdateAccepted UpdateRecipe (string owner, string name, UpdateRepositoryDto updateRepositoryDto)

Update a Recipe

Update a recipe (must have `contribute` permission)

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpdateRecipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: Compulsory Auth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new RecipesApi(Configuration.Default);
            var owner = owner_example;  // string | 
            var name = name_example;  // string | 
            var updateRepositoryDto = new UpdateRepositoryDto(); // UpdateRepositoryDto | 

            try
            {
                // Update a Recipe
                UpdateAccepted result = apiInstance.UpdateRecipe(owner, name, updateRepositoryDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RecipesApi.UpdateRecipe: " + e.Message );
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

