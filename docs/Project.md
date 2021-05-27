
# PollinationSDK.Model.Project

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | The name of the project. Must be unique to a given owner | 
**Description** | **string** | A description of the project | [optional] [default to ""]
**Public** | **bool** | Whether or not a project is publicly viewable | [optional] [default to true]
**Id** | **string** | The project ID | 
**Owner** | [**AccountPublic**](AccountPublic.md) | The project owner | 
**Permissions** | [**UserPermission**](UserPermission.md) |  | 
**Slug** | **string** | The project name in slug format | 
**Usage** | [**Usage**](Usage.md) | The resource consumption of this project | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "Project"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

