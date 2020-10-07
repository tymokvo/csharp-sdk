
# PollinationSDK.Model.Dependency

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Alias** | **string** | An optional alias to refer to this dependency. Useful if the name is already used somewhere else. | [optional] 
**Hash** | **string** | The digest hash of the dependency when retrieved from its source. This is locked when the resource dependencies are downloaded. | [optional] 
**Name** | **string** | Workflow name. This name should be unique among all the resources in your resource. Use an alias if this is not the case. | 
**Source** | **string** | URL to a repository where this resource can be found. | 
**Tag** | **string** | Tag of the resource. | 
**Type** | **DependencyType** |  | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

