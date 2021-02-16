
# PollinationSDK.Model.RunStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Inputs** | [**List&lt;AnyOfStepStringInputStepIntegerInputStepNumberInputStepBooleanInputStepFolderInputStepFileInputStepPathInputStepArrayInputStepJSONObjectInput&gt;**](AnyOfStepStringInputStepIntegerInputStepNumberInputStepBooleanInputStepFolderInputStepFileInputStepPathInputStepArrayInputStepJSONObjectInput.md) | The inputs used for this run. | 
**Outputs** | [**List&lt;AnyOfStepStringOutputStepIntegerOutputStepNumberOutputStepBooleanOutputStepFolderOutputStepFileOutputStepPathOutputStepArrayOutputStepJSONObjectOutput&gt;**](AnyOfStepStringOutputStepIntegerOutputStepNumberOutputStepBooleanOutputStepFolderOutputStepFileOutputStepPathOutputStepArrayOutputStepJSONObjectOutput.md) | The outputs produced by this run. | 
**Status** | **string** | The status of this task. Can be \&quot;Running\&quot;, \&quot;Succeeded\&quot;, \&quot;Failed\&quot; or \&quot;Error\&quot; | 
**StartedAt** | **DateTime** | The time at which the task was started | 
**Id** | **string** | The ID of the individual run. | 
**JobId** | **string** | The ID of the job that generated this run | 
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Message** | **string** | Any message produced by the task. Usually error/debugging hints. | [optional] 
**FinishedAt** | **DateTime** | The time at which the task was completed | [optional] 
**Source** | **string** | Source url for the status object. It can be a recipe or a function. | [optional] 
**ApiVersion** | **string** |  | [optional] [readonly] [default to "v1beta1"]
**Entrypoint** | **string** | The ID of the first step in the run. | [optional] 
**Steps** | [**Dictionary&lt;string, StepStatus&gt;**](StepStatus.md) |  | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "RunStatus"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

