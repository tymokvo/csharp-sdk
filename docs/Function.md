
# PollinationSDK.Model.Function

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Command** | **string** | Full shell command for this function. Each function accepts only one command. The command will be executed as a shell command in operator. For running several commands after each other use &amp;&amp; between the commands or pipe data from one to another using | | 
**Description** | **string** | Function description. A short human readable description for this function. | [optional] 
**Inputs** | [**FunctionInputs**](FunctionInputs.md) | Input arguments for this function. | [optional] 
**Name** | **string** | Function name. Must be unique within an operator. | 
**Outputs** | [**FunctionOutputs**](FunctionOutputs.md) | List of output arguments. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

