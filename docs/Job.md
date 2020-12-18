
# PollinationSDK.Model.Job

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Source** | **string** | The source url for downloading the recipe. | 
**Type** | **string** |  | [optional] [readonly] [default to "Job"]
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**ApiVersion** | **string** |  | [optional] [readonly] [default to "v1beta1"]
**Arguments** | [**List&lt;AnyOfJobArgumentJobPathArgument&gt;**](AnyOfJobArgumentJobPathArgument.md) | Input arguments for this job. | [optional] 
**Name** | **string** | An optional name for this job. This name will be used a the display name for the run. | [optional] 
**Description** | **string** | Run description. | [optional] 
**Labels** | **Dictionary&lt;string, string&gt;** | Optional user data as a dictionary. User data is for user reference only and will not be used in the execution of the job. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

