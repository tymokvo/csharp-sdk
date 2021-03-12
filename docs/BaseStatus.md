
# PollinationSDK.Model.BaseStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Inputs** | [**List&lt;AnyType&gt;**](AnyType.md) | Place-holder. Overwrite this! | [optional] 
**Outputs** | [**List&lt;AnyType&gt;**](AnyType.md) | Place-holder. Overwrite this! | [optional] 
**StartedAt** | **DateTime** | The time at which the task was started | 
**Message** | **string** | Any message produced by the task. Usually error/debugging hints. | [optional] 
**FinishedAt** | **DateTime** | The time at which the task was completed | [optional] 
**Source** | **string** | Source url for the status object. It can be a recipe or a function. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "BaseStatus"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

