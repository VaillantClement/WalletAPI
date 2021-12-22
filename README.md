# WalletAPI
**Version: 1.0**

## Scenario

WalletAPI is a WebAPI mixed with an ASP.NET Web MVC application. 
It allows users to login, create and get details of an account.

The WebAPI uses a basic authentication filter that can be found in the WalletAPI.Modules/BasicAuthHttpModule.


### Running the application

- First you will need to connect to any SQL instance running locally in the machine where the solution WalletAPI is open.
- At the root of the solution, find the file SQLCreationScript.sql and execute it on your SQL server. 
	This will create the DB, tables and insert basic data needed to first run the application. 
- Before to run the project, you have to modify 2 connection strings in order to point to your DB server:
	- Modify WalletAPI/Web.config 
	- Modify WalletAPI.DAL/App.config
	
	Scroll to the connectionStrings node and in the WalletEntities replace the values in the connectionString param, between &quot; and &quot;" by using the string below:	
	
	Use the following and replace the data source value by your SQL server instance name, using a valid user id and password:
	
	data source=.\SQLEXPRESS;user id=;password=;initial catalog=Wallet;persist security info=True;MultipleActiveResultSets=True;App=EntityFramework

- Make sure WalletAPI is set as the startup project 
- Hit F5 or press Execute (using IISExpress), the project is running!


### Extras

- Kindly find a postman collection containing 3 functional calls that you can import and run in postman (when the project is running)
- Time passed: 16 hours 

- Solution provided is not finished. APIs and UI are incomplete. 