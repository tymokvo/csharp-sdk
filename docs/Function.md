
# PollinationSDK.Model.Function

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Command** | **string** | Full shell command for this function. Each function accepts only one command. The command will be executed as a shell command in plugin. For running several commands after each other use &amp;&amp; between the commands or pipe data from one to another using | | 
**Description** | **string** | Function description. A short human readable description for this function. | [optional] 
**Inputs** | [**List&lt;AnyOfFunctionStringInputFunctionIntegerInputFunctionNumberInputFunctionBooleanInputFunctionFolderInputFunctionFileInputFunctionPathInputFunctionArrayInputFunctionJSONObjectInput&gt;**](AnyOfFunctionStringInputFunctionIntegerInputFunctionNumberInputFunctionBooleanInputFunctionFolderInputFunctionFileInputFunctionPathInputFunctionArrayInputFunctionJSONObjectInput.md) | Input arguments for this function. | [optional] 
**Name** | **string** | Function name. Must be unique within a plugin. | 
**Outputs** | [**List&lt;AnyOfFunctionStringOutputFunctionIntegerOutputFunctionNumberOutputFunctionBooleanOutputFunctionFolderOutputFunctionFileOutputFunctionPathOutputFunctionArrayOutputFunctionJSONObjectOutput&gt;**](AnyOfFunctionStringOutputFunctionIntegerOutputFunctionNumberOutputFunctionBooleanOutputFunctionFolderOutputFunctionFileOutputFunctionPathOutputFunctionArrayOutputFunctionJSONObjectOutput.md) | List of output arguments. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "Function"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

