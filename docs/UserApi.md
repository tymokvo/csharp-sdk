# PollinationSDK.Api.UserApi

All URIs are relative to *https://api.pollination.cloud*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ChangePassword**](UserApi.md#changepassword) | **POST** /user/change_password | Make a password change request
[**GetMe**](UserApi.md#getme) | **GET** /user | Get authenticated user profile.
[**GetRoles**](UserApi.md#getroles) | **GET** /user/roles | Get the authenticated user roles
[**ListRefreshTokens**](UserApi.md#listrefreshtokens) | **GET** /user/tokens | Get a list of token names
[**Login**](UserApi.md#login) | **POST** /user/login | Login to the platform and get a JWT back
[**Signup**](UserApi.md#signup) | **POST** /user/signup | Sign Up to the platform!
[**UpsertRefreshToken**](UserApi.md#upsertrefreshtoken) | **POST** /user/tokens | Get refresh token and delete previous one if it exists



## ChangePassword

> AnyType ChangePassword (EmailRequest emailRequest)

Make a password change request

Make a password change request

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ChangePasswordExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UserApi(Configuration.Default);
            var emailRequest = new EmailRequest(); // EmailRequest | 

            try
            {
                // Make a password change request
                AnyType result = apiInstance.ChangePassword(emailRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.ChangePassword: " + e.Message );
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
 **emailRequest** | [**EmailRequest**](EmailRequest.md)|  | 

### Return type

[**AnyType**](AnyType.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **404** | Not found |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetMe

> UserPrivate GetMe ()

Get authenticated user profile.

Get authenticated user profile

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetMeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new UserApi(Configuration.Default);

            try
            {
                // Get authenticated user profile.
                UserPrivate result = apiInstance.GetMe();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.GetMe: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**UserPrivate**](UserPrivate.md)

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRoles

> List&lt;string&gt; GetRoles ()

Get the authenticated user roles

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class GetRolesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: CompulsoryAuth
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new UserApi(Configuration.Default);

            try
            {
                // Get the authenticated user roles
                List<string> result = apiInstance.GetRoles();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.GetRoles: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

[CompulsoryAuth](../README.md#CompulsoryAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListRefreshTokens

> List&lt;RefreshToken&gt; ListRefreshTokens ()

Get a list of token names

Get a list of token names

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class ListRefreshTokensExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            // Configure OAuth2 access token for authorization: JWT
            Configuration.Default.AccessToken = "YOUR_JWT_TOKEN";

            var apiInstance = new UserApi(Configuration.Default);

            try
            {
                // Get a list of token names
                List<RefreshToken> result = apiInstance.ListRefreshTokens();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.ListRefreshTokens: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**List&lt;RefreshToken&gt;**](RefreshToken.md)

### Authorization

[JWT](../README.md#JWT)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## Login

> LoginToken Login (Login login)

Login to the platform and get a JWT back

Login a user

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class LoginExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UserApi(Configuration.Default);
            var login = new Login(); // Login | 

            try
            {
                // Login to the platform and get a JWT back
                LoginToken result = apiInstance.Login(login);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.Login: " + e.Message );
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
 **login** | [**Login**](Login.md)|  | 

### Return type

[**LoginToken**](LoginToken.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
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


## Signup

> AnyType Signup (SignUp signUp)

Sign Up to the platform!

Sign Up a new user

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class SignupExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UserApi(Configuration.Default);
            var signUp = new SignUp(); // SignUp | 

            try
            {
                // Sign Up to the platform!
                AnyType result = apiInstance.Signup(signUp);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.Signup: " + e.Message );
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
 **signUp** | [**SignUp**](SignUp.md)|  | 

### Return type

[**AnyType**](AnyType.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successful Response |  -  |
| **403** | Access forbidden |  -  |
| **500** | Server error |  -  |
| **400** | Invalid request |  -  |
| **202** | Accepted |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertRefreshToken

> string UpsertRefreshToken (RefreshTokenCreate refreshTokenCreate)

Get refresh token and delete previous one if it exists

Get refresh token and delete previous one if it exists

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PollinationSDK.Api;
using PollinationSDK.Client;
using PollinationSDK.Model;

namespace Example
{
    public class UpsertRefreshTokenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.pollination.cloud";
            var apiInstance = new UserApi(Configuration.Default);
            var refreshTokenCreate = new RefreshTokenCreate(); // RefreshTokenCreate | 

            try
            {
                // Get refresh token and delete previous one if it exists
                string result = apiInstance.UpsertRefreshToken(refreshTokenCreate);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UserApi.UpsertRefreshToken: " + e.Message );
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
 **refreshTokenCreate** | [**RefreshTokenCreate**](RefreshTokenCreate.md)|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

