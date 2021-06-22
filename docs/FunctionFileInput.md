
# PollinationSDK.Model.FunctionFileInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Alias** | [**List&lt;AnyOfDAGGenericInputAliasDAGStringInputAliasDAGIntegerInputAliasDAGNumberInputAliasDAGBooleanInputAliasDAGFolderInputAliasDAGFileInputAliasDAGPathInputAliasDAGArrayInputAliasDAGJSONObjectInputAliasDAGLinkedInputAlias&gt;**](AnyOfDAGGenericInputAliasDAGStringInputAliasDAGIntegerInputAliasDAGNumberInputAliasDAGBooleanInputAliasDAGFolderInputAliasDAGFileInputAliasDAGPathInputAliasDAGArrayInputAliasDAGJSONObjectInputAliasDAGLinkedInputAlias.md) | A list of aliases for this input in different platforms. | [optional] 
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Default** | [**AnyOfHTTPS3ProjectFolder**](AnyOfHTTPS3ProjectFolder.md) | The default source for file if the value is not provided. | [optional] 
**Description** | **string** | Optional description for input. | [optional] 
**Extensions** | **List&lt;string&gt;** | Optional list of extensions for file. The check for extension is case-insensitive. | [optional] 
**Name** | **string** | Input name. | 
**Path** | **string** | Path to the target location that the input will be copied to.  This path is relative to the working directory where the command is executed. | 
**Required** | **bool** | A field to indicate if this input is required. This input needs to be set explicitly even when a default value is provided. | [optional] [default to false]
**Spec** | **Object** | An optional JSON Schema specification to validate the input value. You can use validate_spec method to validate a value against the spec. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "FunctionFileInput"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

