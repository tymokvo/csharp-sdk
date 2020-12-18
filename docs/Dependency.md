
# PollinationSDK.Model.Dependency

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kind** | **DependencyKind** | The kind of dependency. It can be a recipe or an plugin. | 
**Name** | **string** | Workflow name. This name should be unique among all the resources in your resource. Use an alias if this is not the case. | 
**Tag** | **string** | Tag of the resource. | 
**Source** | **string** | URL to a repository where this resource can be found. | 
**Type** | **string** |  | [optional] [readonly] [default to "Dependency"]
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Hash** | **string** | The digest hash of the dependency when retrieved from its source. This is locked when the resource dependencies are downloaded. | [optional] 
**Alias** | **string** | An optional alias to refer to this dependency. Useful if the name is already used somewhere else. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

