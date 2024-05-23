# PatientInfoPortal
## Prerequisites
1. .NET 8 SDK
2. Visual Studio 2022 (with ASP.NET and Web Development workload)
3. Microsoft SQL Server 2022

## Project Structure
The Solution contains three projects.
1. PatientInfoPortal.Api (backend - WebAPI)
2. PatientInfoPortal.App (frontend - MVC)
3. PatientInfoPortal.Shared (Class Library)

## Steps to run
1. Clone the repository.
2. Run the SQL Script in a new or existing database to create the tables. (database_schema.sql)
3. Open the solution in Visual Studio.
4. replace the ConnectionString (DbConn) in appsettings.json file in the PatientInfoPortal.Api project with your database connection string.
5. Edit the Program.cs file in PatientInfoPortal.App project to set your port for API (if necessary).
```
// Add services to the container.
builder.Services.AddHttpClient<ApiService>(service =>
    
service.BaseAddress = new Uri("https://localhost:7186/")
);
```
6. In visual studio configure startup project to start both PatientInfoPortal.Api (first) and PatientInfoPortal.App project.
7. Start the application in visual studio. Two browser window should open for swagger and the application.
