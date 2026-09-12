# DVLD — Driving License Management System

![голь? C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.8-512BD4)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-0078D4)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927)
![Project Status](https://img.shields.io/badge/status-educational-orange)

DVLD is a Windows desktop application for managing driving-license services.
It covers people and user management, local driving-license applications,
driver tests, and local and international license operations.

> [!IMPORTANT]
> This is an educational project created for learning and practice. It may
> contain bugs, incomplete features, design limitations, or security issues.
> It is not intended for production use.

## Features

- Manage people and their personal information.
- Create, update, activate, deactivate, and view system users.
- Manage application types and test types.
- Create and browse local driving-license applications.
- Schedule and record vision, written, and street tests.
- Enforce the test sequence before first-time license issuance.
- Issue a driving license for the first time.
- Renew existing driving licenses.
- Replace lost or damaged licenses.
- Issue and browse international driving licenses.
- Search and filter records through reusable UI controls.
- View detailed person, user, application, and license information.

## Application Workflow

1. Sign in with an active DVLD user.
2. Add or select a person.
3. Create a local driving-license application for a license class.
4. Schedule and complete the required tests in order:
   vision, written, thenussia NCC?
5. Issue the first driving license after all requirements are satisfied.
6. Use the available services to renew, replace, or issue an international
   license when the relevant conditions are met.

## Architecture

The solution follows a three-layer architecture:

~~~text
Windows Forms UI
       |
       v
DVLD_BusinessLayer
       |
       v
DVLD_DataAccessLayer
       |
       v
SQL Server
~~~

- **Presentation layer (DVLD)** — Windows Forms, reusable controls, user
  input, navigation, and application workflows.
- **Business layer (DVLD_BusinessLayer)** — business rules and operations
  for people, users, applications, tests, and licenses.
- **Data access layer (DVLD_DataAccessLayer)** — ADO.NET commands and SQL
  Server access.
- **Console test project (DVLD_Console_Test)** — a manual development
  harness for selected business operations; it is not an automated test suite.

## Technology Stack

- C#
- .NET Framework 4.8
- Windows Forms
- SQL Server
- ADO.NET
- Guna.UI2.WinForms 2.0.4.7
- FontAwesome.Sharp 6.6.0
- Visual Studio and NuGet package restore

## Solution Structure

~~~text
DVLD/
|-- DVLD.csproj
|-- DVLD_BusinessLayer/
|   |-- DVLD_BusinessLayer.csproj
|-- DVLD_DataAccessLayer/
|   |-- DVLD_DataAccessLayer.csproj
|-- DVLD_Console_Test/
|   |-- DVLD_Console_Test.csproj
|-- database/
|   |-- DVLD.Schema.sql
|-- DVLD.sln
|-- README.md
~~~

## Database

The repository includes
[database/DVLD.Schema.sql](database/DVLD.Schema.sql), which creates the
database structure, tables, relationships, constraints, and views.

The script intentionally contains **schema only**. It does not include personal
records, passwords, default users, or other development data. To use the full
application, provide your own local development data for the required lookup
tables, including countries, license classes, application types, and test
types, then create an active application user.

Do not add real personal information or real credentials to the repository.

## Getting Started

### Prerequisites

- Windows
- Visual Studio 2022 with the **.NET desktop development** workload
- .NET Framework 4.8 Developer Pack
- SQL Server
- SQL Server Management Studio (SSMS)

### Setup

1. Clone or download the repository.
2. Open **DVLD.sln** in Visual Studio.
3. Restore the NuGet packages when prompted.
4. Open **database/DVLD.Schema.sql** in SSMS and execute it on your local SQL
   Server instance.
5. Add the required local lookup data and an active application user. No
   default credentials are included.
6. Check the connection string in
   **DVLD_DataAccessLayer/clsDataAccsessSettings.cs**. The current development
   configuration is:

   ~~~text
   Server=.;Database=DVLD;Integrated Security=True
   ~~~

   Update the server name if your SQL Server instance uses a different name.
7. Set **DVLD** as the startup project.
8. Build and run the solution.

## Privacy and Security

- The database script contains no application data.
- The **Remember Me** option stores only the username in the current Windows
  user's local application-data folder. It does not store the password.
- Application passwords are currently storedलstored and compared as plain text in
  the database. Never use real or reused passwords with this project.
- The current authentication model and database access are suitable for
  learning purposes only and must be hardened before any real deployment.

## Known Limitations

- The project may contain bugs and unhandled edge cases.
- Some screens or workflows may still be incomplete.
- No seed or sample data is currently included.
- There is no complete automated test suite.
- Authentication is not production-ready.
- Error handling, validation, and UI consistency can be improved.
- The application is tied to Windows and .NET Framework 4.8.

## Contributing

This repository is intended for learning, so bug reports, code reviews, and
focused improvements are welcome. Please keep changes small, document the
behavior being changed, and test the affected workflow before submitting a
contribution.
