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
3. Run the API:
```bash
dotnet run
```

Upon entering `dotnet run`, the program will automatically import the CSV files into the database.

The API will be available at `http://localhost:5098` based on the project's `launchSettings.json`.
The Swagger link can be accessed in this link: [Swagger Index URL](http://localhost:5098/swagger/index.html)

### Frontend
1. Navigate to the Angular project folder:
```bash
cd UI/pizza-sales-ui
```
2. Install dependencies:
```bash
npm install
```
3. Run the frontend:
```bash
ng serve
```
Visit `http://localhost:4200` in your browser.

## Dependencies
- .NET 8, Entity Framework Core, CsvHelper
- Angular, Angular Router, HttpClient, ngx-charts, Bootstrap 5, etc.

## Notes
- Ensure the API allows CORS from `http://localhost:4200`
- The application will seed the database with data from the CSV on first run
- All logic is modular and follows clean architecture principles
