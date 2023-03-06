# Pogwarts - Backend

## Requirements
  - MS SQL Server
  - Visual Studio

## Installation

  - Clone repository
  - Rename appsettingsdefault.json to appsettings.json
  - Change the connection string for your MS SQL Server in appsettings.json
  - In Package Manager Console run the following:
```
Add-Migration initial
Update-Database
```
  - Run the application
