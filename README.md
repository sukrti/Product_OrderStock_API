# Product_OrderStock_API
This is a project with two entry points, a console app and an ASP.NET web app, which are connected to the REST-API. There are two main services of Orders and Stocks.

1. OrderServices fetches all the orders that are with the status inprogress . Excepted functionality is to fetch the top 5 orders out of all the inprogress orders.
2. StockServices updates the stock of the selected product to 25.

Both the services are executed by using APIs and are called from Console application and Web application. 

Modules in the project:

1. APIEntities- This project contains all the required classes those will be used in the project. Classes are divided under folders : Dtos, Enums,Products.
 
2. APIBusinessLogic- This project deals with the actual logic of dealing with APIs and returing their results to the caller.
This project contains folders: Orders and Stock.
--> Orders contains Interface and a service class. This deals with all the methods required to fetch Order details from the API.
--> Stocks contains Interface and a service class. This deals with all the methods required to update the stock details from the API

3. API-ConsoleApplication- This is a console application that uses business layer for the service and show output on the console window.
--> Program.cs class uses custom dependency injection to configure services and create host buider.
--> Product handler handles both Orders and stock services and internally calls ProductOrderHandler and ProductStockHandler.
--> ProductOrderHandler and ProductStockHandler uses the services provided by APIBusinessLogic.

4. API-Web Application- This is a web application that uses business layer for the service and show output in the web page. 
--> Startup.cs and program.cs creats host builder and configure services
--> Utility folder contains the class that handles Exception globally and this middleware is set up in startup.cs
--> Exception folder contains all the classes with the known exceptions.
--> Controllers contains ProductOrdercontroller and StockOrderController that deals with Order and Stock services  provided by APIBusinessLogic. 
--> www.root contains all the folders HTML, CSS and JS files required for the web application functionality in the front end.

5. API.Tests- This is xunit testing project. That tests the functionality of getting the "top 5" records from all the in progress orders

Additional Notes:

1. Requirement was to check the "top 5" functionality that is implemented and hence the actual method was required to call in the unit test. Its alternative is the TDD
  approach where mocking is required  .
2. If the project is hosted in cloud the logger would be used to track the user activity and exceptions stack trace.

 





