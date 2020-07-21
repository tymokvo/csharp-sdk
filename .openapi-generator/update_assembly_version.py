import re, os, json
from datetime import datetime

now = datetime.now()
deltaTime = (int)((now - datetime(now.year, 1, 1, 0, 0, 0)).total_seconds())


config_file = os.path.join(os.getcwd(), '.openapi-generator', 'config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

schema_version = config_data["packageVersion"] + f'.{deltaTime}'

assembly_file = os.path.join(os.getcwd(), 'src', 'PollinationSDK', 'PollinationSDK.csproj')

with open(assembly_file, encoding='utf-8', mode='r') as csFile:
    s = csFile.read()
with open(assembly_file, encoding='utf-8', mode='w') as f:
    s = re.sub(r"(?<=\SVersion\>)\S+(?=\<\/)", schema_version, s)
    print(f"Update AssemblyVersion to: {schema_version}")
    f.write(s)
