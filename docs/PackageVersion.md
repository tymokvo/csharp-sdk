
# PollinationSDK.Model.PackageVersion

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Package name. Make it descriptive and helpful ;) | 
**Tag** | **string** | The tag of the package | 
**AppVersion** | **string** | The version of the application code underlying the manifest | [optional] 
**Keywords** | **List&lt;string&gt;** | A list of keywords to search the package by | [optional] 
**Maintainers** | [**List&lt;Maintainer&gt;**](Maintainer.md) | A list of maintainers for the package | [optional] 
**Home** | **string** | The URL of this package&#39;s home page | [optional] 
**Sources** | **List&lt;string&gt;** | A list of URLs to source code for this project | [optional] 
**Icon** | **string** | A URL to an SVG or PNG image to be used as an icon | [optional] 
**Deprecated** | **bool** | Whether this package is deprecated | [optional] 
**Description** | **string** | A description of what this package does | [optional] 
**License** | **string** | The License file string for this package | [optional] 
**Url** | **string** |  | 
**Created** | **DateTime** |  | 
**Digest** | **string** |  | 
**Slug** | **string** | A slug of the repository name and the package name. | [optional] 
**Type** | **string** | The type of Queenbee package (ie: recipe or operator) | [optional] [default to ""]
**Readme** | **string** | The README file string for this package | [optional] 
**Manifest** | [**AnyOfRecipeOperator**](AnyOfRecipeOperator.md) | The package Recipe or Operator manifest | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

