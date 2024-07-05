# MovieManager Film.io

- Add, Update, View, Search and Delete movies
- Movies can be linked to multiple genres and actors

## Run locally

- Clone this repo and `cd MovieManager`
- Pre-requisite: SQL server local DB should be running. DB connection config configurable in `appsettings.json`
- `dotnet run`

## Tech stack

- C#
- ASP.NET MVC
- SQL Server (+ EF Core)

## Additional information

- Database will be created if it does not exist
- Database will be seeded if no movies exist
