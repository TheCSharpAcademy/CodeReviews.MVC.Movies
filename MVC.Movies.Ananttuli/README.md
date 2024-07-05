# MovieManager Film.io

Add, Update, View, Search and Delete movies

## Run locally

- Clone this repo and `cd MovieManager`
- Pre-requisite: SQL server local DB should be running. DB connection config configurable in `appsettings.json`
- `dotnet ef database update`
- `dotnet run`

## Tech stack

- C#
- ASP.NET MVC
- SQL Server (+ EF Core)

## Additional information

- Database will be created if it does not exist
- Database will be seeded if no movies exist
