
# PollinationSDK.Model.DAGGenericOutputAlias

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**From** | [**AnyType**](.md) | Reference to a file or a task output. Task output must be file. | 
**Platform** | **List&lt;string&gt;** | Name of the client platform (e.g. Grasshopper, Revit, etc). The value can be any strings as long as it has been agreed between client-side developer and author of the recipe. | 
**Handler** | [**List&lt;IOAliasHandler&gt;**](IOAliasHandler.md) | List of process actions to process the input or output value. | 
**Type** | **string** |  | [optional] [readonly] [default to "DAGGenericOutputAlias"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

