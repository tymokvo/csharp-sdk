
# PollinationSDK.Model.DAGLinkedOutputAlias

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Description** | **string** | Optional description for output. | [optional] 
**Handler** | [**List&lt;IOAliasHandler&gt;**](IOAliasHandler.md) | List of process actions to process the input or output value. | 
**Name** | **string** | Output name. | 
**Platform** | **List&lt;string&gt;** | Name of the client platform (e.g. Grasshopper, Revit, etc). The value can be any strings as long as it has been agreed between client-side developer and author of the recipe. | 
**Type** | **string** |  | [optional] [readonly] [default to "DAGLinkedOutputAlias"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

