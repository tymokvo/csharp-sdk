
# PollinationSDK.Model.PackageVersion

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**AppVersion** | **string** | The version of the application code underlying the manifest | [optional] 
**Created** | **DateTime** |  | 
**Deprecated** | **bool** | Whether this package is deprecated | [optional] 
**Description** | **string** | A description of what this package does | [optional] 
**Digest** | **string** |  | 
**Home** | **string** | The URL of this package&#39;s home page | [optional] 
**Icon** | **string** | A URL to an SVG or PNG image to be used as an icon | [optional] 
**Keywords** | **List&lt;string&gt;** | A list of keywords to search the package by | [optional] 
**Kind** | **string** | The type of Queenbee package (ie: recipe or plugin) | [optional] [default to ""]
**License** | [**License**](License.md) | The license information. | [optional] 
**Maintainers** | [**List&lt;Maintainer&gt;**](Maintainer.md) | A list of maintainers for the package | [optional] 
**Manifest** | [**AnyOfRecipePlugin**](AnyOfRecipePlugin.md) | The package Recipe or Plugin manifest | [optional] 
**Name** | **string** | Package name. Make it descriptive and helpful ;) | 
**Readme** | **string** | The README file string for this package | [optional] 
**Slug** | **string** | A slug of the repository name and the package name. | [optional] 
**Sources** | **List&lt;string&gt;** | A list of URLs to source code for this project | [optional] 
**Tag** | **string** | The tag of the package | 
**Type** | **string** |  | [optional] [readonly] [default to "PackageVersion"]
**Url** | **string** |  | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

