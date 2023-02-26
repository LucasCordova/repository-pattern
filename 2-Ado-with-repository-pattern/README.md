# ADO.NET using Repository Pattern

## Pre-requisites

1. In SQL Server, run BikeStoreV2 DB script `init-db-script` 0-Demo-Database.
2. Install the following nuget packages:
    - dotnet add package Microsoft.Extensions.Configuration
    - dotnet add package Microsoft.Extensions.Configuration.Json
    - dotnet add package Microsoft.Extensions.Configuration.FileExtensions
    - dotnet add package System.Data.SqlClient
3. Edit your connection string in `appsettings.json`.

## Build and run project

In the terminal, use the command:  `dotnet build; dotnet run;`

## Expected output

```txt
All customers:
1 Debra Burks
2 Kasha Todd
3 Tameka Fisher
4 Daryl Spence
5 Charolette Rice
.
.
.
1443 Lezlie Lamb
1444 Ivette Estes
1445 Ester Acevedo

Customer with Id 1:
1 Debra Burks

Add customer:
Customer added: Luke Skywalker

Update customer:
Customer's name changed to: Luke Skywalker-Vader

Delete customer:
Customer deleted: Luke Skywalker-Vader
```
