
# PollinationSDK.Model.DAGTask

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Arguments** | [**DAGTaskArgument**](DAGTaskArgument.md) | The input arguments for this task | [optional] 
**Dependencies** | **List&lt;string&gt;** | Dependencies are name of other DAG steps which this depends on. | [optional] 
**Loop** | [**DAGTaskLoop**](DAGTaskLoop.md) | List of inputs to loop over. | [optional] 
**Name** | **string** | Name for this step. It must be unique in DAG. | 
**Outputs** | [**DAGTaskOutputs**](DAGTaskOutputs.md) | The outputs of this task | [optional] 
**SubFolder** | **string** | A path relative to the current folder context where artifacts should be saved. This is useful when performing a loop or invoking another workflow and wanting to save results in a specific folder. | [optional] 
**Template** | **string** | Template name. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

