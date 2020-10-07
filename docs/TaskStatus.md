
# PollinationSDK.Model.TaskStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BoundaryId** | **string** | This indicates the task ID of the associated template root             task in which this task belongs to. A DAG task will have the id of the             parent DAG for example. | [optional] 
**Children** | **List&lt;string&gt;** | A list of child task IDs | 
**Command** | **string** | The command used to run this task. Only applies to Function tasks. | [optional] 
**FinishedAt** | **DateTime** | The time at which the task was completed | [optional] 
**Id** | **string** | The task unique ID | 
**Inputs** | [**Arguments**](Arguments.md) | The inputs used by this task | 
**Message** | **string** | Any message produced by the task. Usually error/debugging hints. | [optional] 
**Name** | **string** | A human readable name for the task. Usually defined by the DAG task name but can be extended if the task is part of a loop for example. This name is unique within the boundary of the DAG/Workflow that generated it. | 
**OutboundTasks** | **List&lt;string&gt;** | A list of the last tasks to ran in the context of this task. In the case of a DAG or a workflow this will be the last task that has been executed. It will remain empty for functions. | 
**Outputs** | [**Arguments**](Arguments.md) | The outputs produced by this task | 
**StartedAt** | **DateTime** | The time at which the task was started | 
**Status** | **string** | The status of this task. Can be \&quot;Running\&quot;, \&quot;Succeeded\&quot;, \&quot;Failed\&quot; or \&quot;Error\&quot; | 
**TemplateRef** | **string** | The name of the template that spawned this task | 
**Type** | **StatusType** |  | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

