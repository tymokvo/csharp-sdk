
# PollinationSDK.Model.PackageVersion

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Package name. Make it descriptive and helpful ;) | 
**Tag** | **string** | The tag of the package | 
**Url** | **string** |  | 
**Created** | **DateTime** |  | 
**Digest** | **string** |  | 
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**AppVersion** | **string** | The version of the application code underlying the manifest | [optional] 
**Keywords** | **List&lt;string&gt;** | A list of keywords to search the package by | [optional] 
**Maintainers** | [**List&lt;Maintainer&gt;**](Maintainer.md) | A list of maintainers for the package | [optional] 
**Home** | **string** | The URL of this package&#39;s home page | [optional] 
**Sources** | **List&lt;string&gt;** | A list of URLs to source code for this project | [optional] 
**Icon** | **string** | A URL to an SVG or PNG image to be used as an icon | [optional] 
**Deprecated** | **bool** | Whether this package is deprecated | [optional] 
**Description** | **string** | A description of what this package does | [optional] 
**License** | [**License**](License.md) | The license information. | [optional] 
**Slug** | **string** | A slug of the repository name and the package name. | [optional] 
**Kind** | **string** | The type of Queenbee package (ie: recipe or plugin) | [optional] [default to ""]
**Readme** | **string** | The README file string for this package | [optional] 
**Manifest** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | The package Recipe or Plugin manifest | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "PackageVersion"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

