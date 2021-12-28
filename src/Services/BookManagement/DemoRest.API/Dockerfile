#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/BookManagement/DemoRest.API/DemoRest.API.csproj", "Services/BookManagement/DemoRest.API/"]
COPY ["Services/BookManagement/DemoRest.Core/DemoRest.Core.csproj", "Services/BookManagement/DemoRest.Core/"]
COPY ["Services/BookManagement/DemoRest.Abstraction/DemoRest.Abstraction.csproj", "Services/BookManagement/DemoRest.Abstraction/"]
COPY ["Services/BookManagement/DemoRest.Infrastructure/DemoRest.Infrastructure.csproj", "Services/BookManagement/DemoRest.Infrastructure/"]
RUN dotnet restore "Services/BookManagement/DemoRest.API/DemoRest.API.csproj"
COPY . .
WORKDIR "/src/Services/BookManagement/DemoRest.API"
RUN dotnet build "DemoRest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoRest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoRest.API.dll"]
