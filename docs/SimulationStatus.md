
# PollinationSDK.Model.SimulationStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | ID of the account the simulation is running for. | 
**Entrypoint** | **string** | The ID of the first task in the workflow | [optional] 
**FinishedAt** | **DateTime** | The time at which the task was completed | [optional] 
**Id** | **string** | The ID of the individual workflow run. | 
**Message** | **string** | Any message produced by the task. Usually error/debugging hints. | [optional] 
**Parallelism** | **int** | The max number of parallel tasks running for this simulation | [optional] 
**ProjectId** | **string** | ID of the project the simulation belongs to | 
**RecipeAccountId** | **string** | ID of the recipe owner | 
**RecipeId** | **string** | ID of the recipe repository used to create the workflow | 
**RecipePackageId** | **string** | ID of the specific recipe package used to create the workflow | 
**StartedAt** | **DateTime** | The time at which the task was started | 
**Status** | **string** | The status of this task. Can be \&quot;Running\&quot;, \&quot;Succeeded\&quot;, \&quot;Failed\&quot; or \&quot;Error\&quot; | 
**Tasks** | [**Dictionary&lt;string, TaskStatus&gt;**](TaskStatus.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

