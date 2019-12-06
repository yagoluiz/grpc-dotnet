# gRPC - .NET Core

Comunication API's using [gRPC](https://grpc.io/). 

## Instructions for run project

### Visual Studio

Run projects in [*"multiple startup"*](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2019). 

### Docker

* Grpc.Service:

`docker build -t grpc-service .`

* Grpc.Client:

`docker build -t grpc-client .`

* Docker compose:

`docker-compose up -d .`