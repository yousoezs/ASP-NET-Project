To use this template you need first to understand the structure of the project since this project is made to use Microservices with docker.

First, you need to install docker and docker-compose in your machine. I would recommend Docker Desktop for Windows and Docker for Mac.

When you have that setup, check out the APIs folder, if that is what you want to use, you don't need to change following. If you want to create
new APIs, then follow instructions from number 7.

1. Checkout the Domain Folder, there you have a class library defining some interfaces and a class called GenericRepository. This library is used to
define interfaces that take in generic type in order to create whatever Repository class you want and DTO(Data Transfer Object) and database models.

2. Checkout the Gateway folder, there you have the project Supergateway, that is used to connect with Ocelot, this will be your project connecting with Docker
and ensuring you can fetch other APIs trough the supergateway.

3. Checkout the APIs folder, each API has a a folder structure that is similiar, but note that each has 2 class libraries called BusinessLogic and DataAccess.

4. DataAccess is used for only creating your Database context and models, they all use EntityFramework SQL Server and EntityFramework Tools nuget package.

5. BusinessLogic is the class library where you will implement your logic for Repositories, and your CRUD Operations etc.

6. The main project, the API itself will you will have control how to set up your endpoints.
-------------------------------------------------

7. Delete the projects called ASPNET.Order.API, ASPNET.User.API, ASPNET.Product.API

8. Create your new ASPNET Core Web API project for each API you need. Remember that these folders are Solution Folders, so when you create a new folder and a new project. Ensure that it is existing properly in your root folder outside of visual Studio.

9. If it is not existing properly, create your folders manually in the root folder outside of Visual Studio, and then create them here as well before adding the Projects.

10. When the projects has been added, go to the docker-compose, and open the docker-compose.yml.

11. In there you will se a setup for the APIs that was existing, if you look closely you will see that there are names that need to be changed.

12. Find all names that was corresponding to the old API names, and rename them to the ones you have created in order to create the container in Docker properly.


