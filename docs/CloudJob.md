
# PollinationSDK.Model.CloudJob

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The unique ID for this run | 
**Spec** | [**Job**](Job.md) | The job specification | 
**Author** | [**AccountPublic**](AccountPublic.md) | author | [optional] 
**Owner** | [**AccountPublic**](AccountPublic.md) | owner | [optional] 
**Recipe** | [**RecipeInterface**](RecipeInterface.md) | The recipe used to generate this  | [optional] 
**Status** | [**JobStatus**](JobStatus.md) | The status of the job | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "CloudJob"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

