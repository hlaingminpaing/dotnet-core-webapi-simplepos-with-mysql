# Use the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore dependencies
COPY *.csproj ./ 
RUN dotnet restore

# Copy the rest of the application and build
COPY . ./ 
RUN dotnet publish -c Release -o /app

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "PosWebApi.dll"]
