# Ports-Application 
####  Check out running demo here: http://portsapp.azurewebsites.net/

------------

The ports application that allows to find details about any of the world's ports.
This is a RESTful API application, consisting of a server, built on ASP.NET Core and a client web application, built on Angular 13.
While the server and client parts are configured to run together, each application has its own purpose and is agnostic to the other part, meaning that they are easily replaceable.

**Starting the Application**
- Press CTRL + F5 to run the project or press F5 to run it in debug mode.
- Navigate to http://localhost:5000 to check the web application.

**Application Structure**
- The PortsAPI project is a basic Web API created with ASP.NET Core 3.0+.
- The PortsDAL is the dataAccess layer of the application.
- Teh PortsService layer is where business logic resides.
- The PortsUI client is an Angular web application.



