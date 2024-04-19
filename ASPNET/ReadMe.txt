To use this template you need first to understand the structure of the project since this project is made to use Microservices with docker.

First, you need to install docker and docker-compose in your machine. I would recommend Docker Desktop for Windows and Docker for Mac.

When you have that setup, check out the APIs folder, if that is what you want to use, you don't need to change following. If you want to create
new APIs, then follow instructions from number 7.

1. Checkout the Domain Folder, there you have a class library defining some interfaces and a class called GenericRepository. This library is used to
define interfaces that take in generic type in order to create whatever Repository class you want and DTO(Data Transfer Object) and database models.

2. Checkout the Gateway folder, there you have the project Supergateway, that is used to connect with Ocelot, this will be your project connecting with Docker
and ensuring you can fetch other APIs trough the supergateway.

3. Checkout the APIs folder, each API has a a folder structure that is similiar, but note that each has 2 class libraries called BusinessLogic and DataAccess.

4. DataAccess is used for only creating your Database context and models, in these you can either download the Entityframework packages or MongoDB etc... But if you are using entity framework, do not forget to change global invaraiant mode to false.

5. BusinessLogic is the class library where you will implement your logic for Repositories, and your CRUD Operations etc.

6. The main project, the API itself will you will have control how to set up your endpoints.
-------------------------------------------------

7. Delete the projects called ASPNET.Order.API, ASPNET.User.API, ASPNET.Product.API

8. Create your new ASPNET Core Web API project for each API you need. Remember that these folders are Solution Folders, so when you create a new folder and a new project. Ensure that it is existing properly in your root folder outside of visual Studio.

9. If it is not existing properly, create your folders manually in the root folder outside of Visual Studio, and then create them here as well before adding the Projects.

10. When the projects has been added, go to the docker-compose, and open the docker-compose.yml.

11. In there you will se a setup for the APIs that was existing, if you look closely you will see that there are names that need to be changed.

12. Find all names that was corresponding to the old API names, and rename them to the ones you have created in order to create the container in Docker properly.

13. Below you will se the docker-compose.yml, i have marked each instance that needs to be changed with // when you have created your own design.

version: '3.4'

networks:
    //orderNetwork:    
    //productNetwork:
    //userNetwork:
    gatewayNetwork:


services:

  aspnet.supergateway:
    image: ${DOCKER_REGISTRY-}aspnetsupergateway
    build:
      context: .
      dockerfile: Gateway/aspnet.SuperGateway/Dockerfile
    networks:
      - gatewayNetwork
    depends_on:
      //- aspnet.order.api
      //- aspnet.product.api
      //- aspnet.user.api
    ports:
      - "5000:8080"


  //aspnet.order.api:
    //image: ${DOCKER_REGISTRY-}aspnetorderapi
    build:
      context: .
      //dockerfile: APIs/Order/ASPNET.Order.API/Dockerfile
    networks:
      //- productNetwork
      - gatewayNetwork
    depends_on:
      //- aspnet.order.db
    environment:
      //- DB_HOST_ORDER=aspnet.order.db
      //- DB_DATABASE_ORDER=ASPNETOrderDB
      //- DB_USER_ORDER=sa
      //- DB_MSSQL_SA_PASSWORD_ORDER=Pwd123!!1

  //aspnet.product.api:
    //image: ${DOCKER_REGISTRY-}aspnetproductapi
    build:
      context: .
      //dockerfile: APIs/Product/ASPNET.Product.API/Dockerfile
    networks:
      //- productNetwork
      - gatewayNetwork
    depends_on:
      //- aspnet.user.db
    environment:
      //- DB_HOST_PRODUCT=aspnet.product.db
      //- DB_DATABASE_PRODUCT=ASPNETProductDB

  //aspnet.user.api:
    //image: ${DOCKER_REGISTRY-}aspnetuserapi
    build:
      context: .
      //dockerfile: APIs/User/ASPNET.User.API/Dockerfile
    networks:
      //- userNetwork
      - gatewayNetwork
    depends_on:
      //- aspnet.user.db
    environment:
      //- DB_HOST_USER=aspnet.user.db
      //- DB_DATABASE_USER=ASPNETUserDB
      //- DB_USER_USER=sa
      //- DB_MSSQL_SA_PASSWORD_USER=Pwd123!!1
      

  //aspnet.order.db:
    container_name: orderdb
    image: mcr.microsoft.com/mssql/server:2019-latest
    networks:
      //- orderNetwork
    ports:
      - "7000:1433"
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Pwd123!!1
      - MSSQL_PID=Developer

  //aspnet.product.db:
    //container_name: productdb
    image: mongo:latest
    networks:
      //- productNetwork
    ports:
      - "7002:27017"

  //aspnet.user.db:
    //container_name: userdb
    image: mcr.microsoft.com/mssql/server:2019-latest
    networks:
      //- userNetwork
    ports:
      - "7001:1433"
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Pwd123!!1
      - MSSQL_PID=Developer


