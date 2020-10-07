#!/bin/bash

python .openapi-generator/pre_gen_script.py "https://api.pollination.cloud/openapi.json"
npx @openapitools/openapi-generator-cli generate -i "https://api.pollination.cloud/openapi.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 
python .openapi-generator/post_gen_script.py "https://api.pollination.cloud/openapi.json" 
