# dotnet-core-webapi-simplepos-with-mysql

## Insert db username, password, hostname and migrate database with below commands ##
```
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet build
dotnet run
```
Now you can test your api http://localhost/api/products
