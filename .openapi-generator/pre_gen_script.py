import os
import sys
import urllib.request
import json
import shutil


args = sys.argv[1:]
url = ""

if args == []:
    url = "https://api.pollination.cloud/openapi.json"
else:
    url = args[0]



json_url = urllib.request.urlopen(url)
data = json.loads(json_url.read())
version = data['info']['version']

print(version)
version = version.replace('v', '')



config_file = os.path.join(os.getcwd(), '.openapi-generator', 'config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

config_data["packageVersion"] = version

with open(config_file, "w") as jsonFile:
    json.dump(config_data, jsonFile, indent=4)


def cleanup(projectName):
    root = os.path.dirname(os.path.dirname(__file__))
    # remove Client folder
    project_dir = os.path.join(root, 'src', projectName)
    target_folder = os.path.join(project_dir, 'Client')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    
    # remove Api folder
    target_folder = os.path.join(project_dir, 'Api')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)

    # remove Model folder
    target_folder = os.path.join(project_dir, 'Model')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    
    # remove docs folder
    target_folder = os.path.join(root, 'docs')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)



cleanup('PollinationSDK')
