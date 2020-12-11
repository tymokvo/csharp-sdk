
# PollinationSDK.Model.MetaData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Package name. Make it descriptive and helpful ;) | 
**Tag** | **string** | The tag of the package | 
**Type** | **string** |  | [optional] [readonly] [default to "MetaData"]
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

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

