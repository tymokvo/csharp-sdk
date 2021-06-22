
# PollinationSDK.Model.StepStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**BoundaryId** | **string** | This indicates the step ID of the associated template root             step in which this step belongs to. A DAG step will have the id of the             parent DAG for example. | [optional] 
**ChildrenIds** | **List&lt;string&gt;** | A list of child step IDs | 
**Command** | **string** | The command used to run this step. Only applies to Function steps. | [optional] 
**FinishedAt** | **DateTime** | The time at which the task was completed | [optional] 
**Id** | **string** | The step unique ID | 
**Inputs** | [**List&lt;AnyOfStepStringInputStepIntegerInputStepNumberInputStepBooleanInputStepFolderInputStepFileInputStepPathInputStepArrayInputStepJSONObjectInput&gt;**](AnyOfStepStringInputStepIntegerInputStepNumberInputStepBooleanInputStepFolderInputStepFileInputStepPathInputStepArrayInputStepJSONObjectInput.md) | The inputs used by this step. | 
**Message** | **string** | Any message produced by the task. Usually error/debugging hints. | [optional] 
**Name** | **string** | A human readable name for the step. Usually defined by the DAG task name but can be extended if the step is part of a loop for example. This name is unique within the boundary of the DAG/Job that generated it. | 
**OutboundSteps** | **List&lt;string&gt;** | A list of the last step to ran in the context of this step. In the case of a DAG or a job this will be the last step that has been executed. It will remain empty for functions. | 
**Outputs** | [**List&lt;AnyOfStepStringOutputStepIntegerOutputStepNumberOutputStepBooleanOutputStepFolderOutputStepFileOutputStepPathOutputStepArrayOutputStepJSONObjectOutput&gt;**](AnyOfStepStringOutputStepIntegerOutputStepNumberOutputStepBooleanOutputStepFolderOutputStepFileOutputStepPathOutputStepArrayOutputStepJSONObjectOutput.md) | The outputs produced by this step. | 
**Source** | **string** | Source url for the status object. It can be a recipe or a function. | [optional] 
**StartedAt** | **DateTime** | The time at which the task was started | 
**Status** | **StepStatusEnum** | The status of this step. | [optional] 
**StatusType** | **StatusType** | The type of step this status is for. Can be \&quot;Function\&quot;, \&quot;DAG\&quot; or \&quot;Loop\&quot; | 
**TemplateRef** | **string** | The name of the template that spawned this step | 
**Type** | **string** |  | [optional] [readonly] [default to "StepStatus"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

