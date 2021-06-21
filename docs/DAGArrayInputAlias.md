
# PollinationSDK.Model.DAGArrayInputAlias

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Default** | [**List&lt;AnyType&gt;**](AnyType.md) | Default value to use for an input if a value was not supplied. | [optional] 
**Description** | **string** | Optional description for input. | [optional] 
**Handler** | [**List&lt;IOAliasHandler&gt;**](IOAliasHandler.md) | List of process actions to process the input or output value. | 
**ItemsType** | **ItemType** | Type of items in an array. All the items in an array must be from the same type. | [optional] 
**Name** | **string** | Input name. | 
**Platform** | **List&lt;string&gt;** | Name of the client platform (e.g. Grasshopper, Revit, etc). The value can be any strings as long as it has been agreed between client-side developer and author of the recipe. | 
**Required** | **bool** | A field to indicate if this input is required. This input needs to be set explicitly even when a default value is provided. | [optional] [default to false]
**Spec** | **Object** | An optional JSON Schema specification to validate the input value. You can use validate_spec method to validate a value against the spec. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "DAGArrayInputAlias"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

