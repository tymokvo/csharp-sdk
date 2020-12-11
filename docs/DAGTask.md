
# PollinationSDK.Model.DAGTask

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name for this task. It must be unique in a DAG. | 
**Template** | **string** | Template name. A template is a Function or a DAG. This template must be available in the dependencies. | 
**Type** | **string** |  | [optional] [readonly] [default to "DAGTask"]
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Needs** | **List&lt;string&gt;** | List of DAG tasks that this task depends on and needs to be executed before this task. | [optional] 
**Arguments** | [**List&lt;AnyOfTaskArgumentTaskPathArgument&gt;**](AnyOfTaskArgumentTaskPathArgument.md) | The input arguments for this task. | [optional] 
**Loop** | [**DAGTaskLoop**](DAGTaskLoop.md) | Loop configuration for this task. | [optional] 
**SubFolder** | **string** | A path relative to the current folder context where artifacts should be saved. This is useful when performing a loop or invoking another workflow and wanting to save results in a specific sub_folder. | [optional] 
**Returns** | [**List&lt;AnyOfTaskReturnTaskPathReturn&gt;**](AnyOfTaskReturnTaskPathReturn.md) | List of task returns. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

