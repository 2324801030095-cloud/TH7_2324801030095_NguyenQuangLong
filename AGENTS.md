# TH7 Insurance Microservices

This repository carries forward the TH6 insurance microservices solution and adds teacher-provided PaymentService and ProductService code for TH7.

## Stack
- .NET 8, ASP.NET Core, MediatR, PostgreSQL, RabbitMQ, Elasticsearch, Steeltoe Eureka
- Vue SPA and Blazor WebAssembly clients

## Build commands
- Full solution: `dotnet build TH7InsuranceMicroservices.sln --nologo`
- PricingService projects: `dotnet build PricingService.slnx --nologo`
- Run TH5 service: `dotnet run --project ./PricingService/PricingService`

Do not run tests unless the user requests them. Integration tests may require Docker and external services.

## Project conventions and safety
- Preserve the inherited service/API/test layout and change only what the TH7 guide requires.
- Keep `.env*`, `appsettings*.json` (except the reviewed, public `PricingService/PricingService/appsettings.json`), secrets, database dumps, archives and build outputs out of Git.
- TH7 adds the teacher-provided PaymentService, PaymentService.Api, PaymentService.Test, ProductService, ProductService.Api, and ProductService.Test projects. Earlier services remain inherited from TH6.
