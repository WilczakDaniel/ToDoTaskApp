FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore
copy *.csproj ./
RUN dotnet restore 

# Copy everything else
COPY . ./
RUN dotnet publish -c Relase -o out 

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","ToDoTaskApp.dll"]
