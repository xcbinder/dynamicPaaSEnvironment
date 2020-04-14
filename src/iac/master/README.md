# Infrastructure as Code for project master Environment

## ARM Templatess 
For project master environment, there's a need to not use nested ARM templates, as this would have to rely on public uris in order to reference child templates. This should be the project starting environment as it includes provisioning a storage account to be used together with a private blob container and temporary SAS tokens (generated for each build)

### Deploying infrastructure manually

#### Master ARM Templates (per project environment Specific)
az group deployment create --name sharedenv-arm-master --resource-group sharedenv-master --template-file master-deploy-environment.json --parameters @master-deploy-environment.parameters.json --debug
