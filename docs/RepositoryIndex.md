
# PollinationSDK.Model.RepositoryIndex

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**ApiVersion** | **string** |  | [optional] [readonly] [default to "v1beta1"]
**Generated** | **DateTime** | The timestamp at which the index was generated | [optional] 
**Metadata** | [**RepositoryMetadata**](RepositoryMetadata.md) | Extra information about the repository | [optional] 
**Plugin** | **Dictionary&lt;string, List&lt;PackageVersion&gt;&gt;** | A dict of plugins accessible by name. Each name key points to a list of plugin versions | [optional] 
**Recipe** | **Dictionary&lt;string, List&lt;PackageVersion&gt;&gt;** | A dict of recipes accessible by name. Each name key points to a list of recipesversions | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "RepositoryIndex"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

