FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoTaskApp/ToDoTaskApp.csproj", "ToDoTaskApp/"]
RUN dotnet restore "ToDoTaskApp/ToDoTaskApp.csproj"
COPY . .
WORKDIR "/src/ToDoTaskApp"
RUN dotnet build "ToDoTaskApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoTaskApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoTaskApp.dll"]
