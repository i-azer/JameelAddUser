Root Directory : 
dotnet-ef migrations add InitialMigration --project JameelApp.EntityFramework.SQLServer --startup-project JameelApp
dotnet-ef database update --project JameelApp.EntityFramework.SQLServer --startup-project JameelApp

