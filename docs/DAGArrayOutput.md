
# PollinationSDK.Model.DAGArrayOutput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Output name. | 
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Description** | **string** | Optional description for output. | [optional] 
**From** | [**AnyOfTaskReferenceFileReference**](AnyOfTaskReferenceFileReference.md) | Reference to a file or a task output. Task output must be file. | 
**Alias** | [**List&lt;AnyOfDAGGenericOutputAliasDAGStringOutputAliasDAGIntegerOutputAliasDAGNumberOutputAliasDAGBooleanOutputAliasDAGFolderOutputAliasDAGFileOutputAliasDAGPathOutputAliasDAGArrayOutputAliasDAGJSONObjectOutputAliasDAGLinkedOutputAlias&gt;**](AnyOfDAGGenericOutputAliasDAGStringOutputAliasDAGIntegerOutputAliasDAGNumberOutputAliasDAGBooleanOutputAliasDAGFolderOutputAliasDAGFileOutputAliasDAGPathOutputAliasDAGArrayOutputAliasDAGJSONObjectOutputAliasDAGLinkedOutputAlias.md) | A list of additional processes for loading this output on different platforms. | [optional] 
**Required** | **bool** | A boolean to indicate if an artifact output is required. A False value makes the artifact optional. | [optional] [default to true]
**ItemsType** | **ItemType** | Type of items in this array. All the items in an array must be from the same type. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "DAGArrayOutput"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

