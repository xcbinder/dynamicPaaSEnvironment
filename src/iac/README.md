# Infrastructure as Code (IaC)

## Master

> Folder : **src/iac/master**

| Azure Service | Description
|--|--|
| **Storage Account** | A Keyvault to keep certificates, secrets across all project environments |
| **KeyVault** | A general purpose storage account to support several project needs. Uses:  1) DevOps and ARM templates deployments |

### ARM TEMPLATES

| Name/File | Description
|--|--|
| **deploy-master.json** | Master environment ARM template to be deployed in any project environment. |
| **deploy-master.parameters.json** | Example of parameters file to run master infrastructure ARM template. |

## Shared Services

> Folder : **src/iac/sharedservices**

| Azure Service | Description
|--|--|
| **CosmosDB** | A single CosmosDB to host the NoSql data layer to all topic environments deployed. |

### ARM TEMPLATES

| Name/File | Description
|--|--|
| **deploy-shared.json** | Shared services ARM template to be deployed in any project environment. |
| **deploy-shared.parameters.json** | Example of parameters file to run shared infrastructure ARM template. |

## Topic 

> Folder : **src/iac/topic**

| Azure Service | Description
|--|--|
| **WebApp** | App Service to host the Web app single page application (SPA). |
| **Service Host Plan** | Service host plan supporting the WebApp. |
| **KeyVault** | Dedicated KeyVault for each topic deployment. Devs can manage their secrets independently. |
| **Function app** | App Service to host the serverless components (Nexus) in a topic deployment|
| **Service Host Plan** | __*Dynamic*__ Service host plan supporting the serverless code. |

### ARM TEMPLATES

| Name/File | Description
|--|--|
| **deploy-keyvault.json** | ARM Template for keyvault |
| **deploy-storage.json** | ARM Template for general purpose az storage |
| **topic-deploy-environment-nexus.json** | ARM template for the Nexus serverless component of a topic environment. |
| **topic-deploy-environment-nexus.parameters.json** | Example of parameters file to run Nexus serverless component of a topic environment. |
| **topic-deploy-environment.parameters.json** | Example of parameters file to run a topic environment ARM template. |
| **topic-deploy-environment.json** | Master ARM template to be deployed for a topic environment. |


