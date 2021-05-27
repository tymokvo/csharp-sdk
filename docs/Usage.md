
# PollinationSDK.Model.Usage

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Start** | **DateTime** | The start date for this usage aggregation | 
**End** | **DateTime** | The end date for this usage aggregation | 
**Cpu** | **double** | cpu usage | [optional] [default to 0D]
**Memory** | **double** | memory usage | [optional] [default to 0D]
**Succeeded** | **int** | succeeded usage | [optional] [default to 0]
**Failed** | **int** | failed usage | [optional] [default to 0]
**DailyUsage** | [**List&lt;DailyUsage&gt;**](DailyUsage.md) | daily breakdown of usage | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "Usage"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

