#!/bin/bash
# This is the file used for local development

npx openapi-generator generate -i "https://api.pollination.cloud/sdk_openapi.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 
python .openapi-generator/post_gen_script.py "https://api.pollination.cloud/sdk_openapi.json" 
