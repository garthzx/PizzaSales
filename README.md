# Pizza Sales Fullstack App

This project is a fullstack web application built with C# .NET (Web API) and Angular for importing and exploring pizza sales data.

## How to Run

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js & npm](https://nodejs.org/)
- SQL Server LocalDB or SQL Server instance

### Database
Go to the `appsettings.json` file in the API project, you will find the Server name in the connection string:

`Server=(localdb)\\MSSQLLocalDB`

Change the server name based on your machine's Sql Server local instance name.

### Backend
1. Navigate to the backend project folder:
```bash
cd src/API
```
2. Restore dependencies:
```bash
dotnet restore
```
3. Update the database:
```bash
dotnet ef database update
```
4. Run the API:
```bash
dotnet run
```

The API will be available at `http://localhost:5098` based on the project's `launchSettings.json`.
The Swagger link can be accessed in this link: [Swagger Index URL](http://localhost:5098/swagger/index.html)

### Frontend
1. From the root directory, navigate to the Angular project:
```bash
cd PizzaSalesUI
```
2. Install dependencies:
```bash
npm install
```
3. Run the frontend:
```bash
ng serve
```
Visit `http://localhost:58613` in your browser. This might change on your machine. Check on `ng serve`'s output instead.

## Dependencies
- .NET 8, Entity Framework Core, CsvHelper
- Angular, Angular Router, HttpClient, ngx-charts, Bootstrap 5, etc.

## Notes
- The API already allows CORS from `http://localhost:58613`. If the port changes, go the Program.cs file of the API and set the correct port. Make sure to re-run `dotnet run`.
- The application will seed the database with data from the CSV on first run
- All logic is modular and follows clean architecture principles
