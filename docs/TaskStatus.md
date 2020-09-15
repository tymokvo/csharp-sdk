
# PollinationSDK.Model.TaskStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Status** | **string** | The status of this task. Can be \&quot;Running\&quot;, \&quot;Succeeded\&quot;, \&quot;Failed\&quot; or \&quot;Error\&quot; | 
**Message** | **string** | Any message produced by the task. Usually error/debugging hints. | [optional] 
**StartedAt** | **DateTime** | The time at which the task was started | 
**FinishedAt** | **DateTime** | The time at which the task was completed | [optional] 
**Id** | **string** | The task unique ID | 
**Name** | **string** | A human readable name for the task. Usually defined by the DAG task name but can be extended if the task is part of a loop for example. This name is unique within the boundary of the DAG/Workflow that generated it. | 
**Type** | **StatusType** |  | 
**TemplateRef** | **string** | The name of the template that spawned this task | 
**Command** | **string** | The command used to run this task. Only applies to Function tasks. | [optional] 
**Inputs** | [**QueenbeeWorkflowArgumentsArguments**](QueenbeeWorkflowArgumentsArguments.md) | The inputs used by this task | 
**Outputs** | [**QueenbeeWorkflowArgumentsArguments**](QueenbeeWorkflowArgumentsArguments.md) | The outputs produced by this task | 
**BoundaryId** | **string** | This indicates the task ID of the associated template root             task in which this task belongs to. A DAG task will have the id of the             parent DAG for example. | [optional] 
**Children** | **List&lt;string&gt;** | A list of child task IDs | 
**OutboundTasks** | **List&lt;string&gt;** | A list of the last tasks to ran in the context of this task. In the case of a DAG or a workflow this will be the last task that has been executed. It will remain empty for functions. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

