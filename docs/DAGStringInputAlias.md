
# PollinationSDK.Model.DAGStringInputAlias

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Platform** | **List&lt;string&gt;** | Name of the client platform (e.g. Grasshopper, Revit, etc). The value can be any strings as long as it has been agreed between client-side developer and author of the recipe. | 
**Handler** | [**List&lt;IOAliasHandler&gt;**](IOAliasHandler.md) | List of process actions to process the input or output value. | 
**Default** | **string** | Default value for generic input. | [optional] 
**Required** | **bool** | A field to indicate if this input is required. This input needs to be set explicitly even when a default value is provided. | [optional] [default to false]
**Spec** | **Object** | An optional JSON Schema specification to validate the input value. You can use validate_spec method to validate a value against the spec. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "DAGStringInputAlias"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

