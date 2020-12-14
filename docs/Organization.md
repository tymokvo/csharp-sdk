
# PollinationSDK.Model.Organization

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | The display name for this org | 
**Picture** | **string** | URL to the picture associated with this org | 
**ContactEmail** | **string** | The contact email for the Organization | 
**Description** | **string** | A description of the org | [optional] [default to ""]
**Id** | **string** | The org ID | 
**Owner** | [**AccountPublic**](AccountPublic.md) | The account the organization represents | 
**Role** | **string** | The role the user has within the organization | [optional] 
**MemberCount** | **int** | The number of members that are part of this org | [optional] [default to 0]
**TeamCount** | **int** | The number of teams that are part of this org | [optional] [default to 0]
**Type** | **string** |  | [optional] [readonly] [default to "Organization"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

