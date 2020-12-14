
# PollinationSDK.Model.DAGArrayOutputAlias

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Output name. | 
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Description** | **string** | Optional description for output. | [optional] 
**From** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | Reference to a file or a task output. Task output must be file. | 
**Platform** | **List&lt;string&gt;** | Name of the client platform (e.g. Grasshopper, Revit, etc). The value can be any strings as long as it has been agreed between client-side developer and author of the recipe. | 
**Handler** | [**List&lt;IOAliasHandler&gt;**](IOAliasHandler.md) | List of process actions to process the input or output value. | 
**ItemsType** | **string** | Type of items in this array. All the items in an array must be from the same type. | [optional] [default to ItemsTypeEnum.String]
**Type** | **string** |  | [optional] [readonly] [default to "DAGArrayOutputAlias"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

