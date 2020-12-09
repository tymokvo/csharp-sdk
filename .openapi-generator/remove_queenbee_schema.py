import os
import sys
import json
import urllib.request
import time


# time.sleep(3)
root = os.getcwd()

def remove_queenbee_schema(source_json):
    
    interface_dir = os.path.join(root, 'src', 'PollinationSDK', 'Interface')
    model_dir = os.path.join(root, 'src', 'PollinationSDK', 'Model')

    with open(source_json, "rb") as jsonFile:
        data = json.load(jsonFile)
    classesItems = data['classes']
    classesItems.update(data['enums'])
    
    for key in classesItems.keys():
        name_space = classesItems[key].title().replace('_', '', 1)
        if name_space.startswith('Queenbee'):
            print(name_space)
            # remove the interface:
            layers = name_space.split('.')
            sub_folders = layers[1:-1]
            sub_dir = os.path.join(interface_dir, *sub_folders)
            interface_file = f"{layers[-1]}.cs"
            if layers[-1] == "_Base":
                interface_file = f"{key}.cs"
            interface_tobe_removed = os.path.join(sub_dir, interface_file)
            if os.path.exists(interface_tobe_removed):
                print(f"Removing {interface_tobe_removed}")
                os.remove(interface_tobe_removed)
            
            # remove classes from honeybee schema
            class_tobe_removed = os.path.join(model_dir, f"{key}.cs")
            if os.path.exists(class_tobe_removed):
                print(f"Removing {class_tobe_removed}")
                os.remove(class_tobe_removed)

args = sys.argv[1:]
json_file = args[0]
print("Start removing queenbee schema classes")
remove_queenbee_schema(json_file)
