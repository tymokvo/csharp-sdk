
# PollinationSDK.Model.RecipeInterface

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**ApiVersion** | **string** |  | [optional] [readonly] [default to "v1beta1"]
**Inputs** | [**List&lt;AnyOfDAGGenericInputDAGStringInputDAGIntegerInputDAGNumberInputDAGBooleanInputDAGFolderInputDAGFileInputDAGPathInputDAGArrayInputDAGJSONObjectInput&gt;**](AnyOfDAGGenericInputDAGStringInputDAGIntegerInputDAGNumberInputDAGBooleanInputDAGFolderInputDAGFileInputDAGPathInputDAGArrayInputDAGJSONObjectInput.md) | A list of recipe inputs. | [optional] 
**Metadata** | [**MetaData**](MetaData.md) | Recipe metadata information. | 
**Outputs** | [**List&lt;AnyOfDAGGenericOutputDAGStringOutputDAGIntegerOutputDAGNumberOutputDAGBooleanOutputDAGFolderOutputDAGFileOutputDAGPathOutputDAGArrayOutputDAGJSONObjectOutput&gt;**](AnyOfDAGGenericOutputDAGStringOutputDAGIntegerOutputDAGNumberOutputDAGBooleanOutputDAGFolderOutputDAGFileOutputDAGPathOutputDAGArrayOutputDAGJSONObjectOutput.md) | A list of recipe outputs. | [optional] 
**Source** | **string** | A URL to the source this recipe from a registry. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "RecipeInterface"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

