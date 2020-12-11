
# PollinationSDK.Model.DockerConfig

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Image** | **string** | Docker image name. Must include tag. | 
**Workdir** | **string** | The working directory the entrypoint command of the container runsin. This is used to determine where to load artifacts when running in the container. | 
**Type** | **string** |  | [optional] [readonly] [default to "DockerConfig"]
**Annotations** | **Dictionary&lt;string, string&gt;** | An optional dictionary to add annotations to inputs. These annotations will be used by the client side libraries. | [optional] 
**Registry** | **string** | The container registry URLs that this container should be pulled from. Will default to Dockerhub if none is specified. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

