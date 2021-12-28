#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/BookLoanManagement/DemoRestTest.API/DemoRestTest.API.csproj", "Services/BookLoanManagement/DemoRestTest.API/"]
COPY ["Services/BookLoanManagement/DemoRestTest.Core/DemoRestTest.Core.csproj", "Services/BookLoanManagement/DemoRestTest.Core/"]
COPY ["Services/BookLoanManagement/DemoRestTest.Abstraction/DemoRestTest.Abstraction.csproj", "Services/BookLoanManagement/DemoRestTest.Abstraction/"]
COPY ["Services/BookLoanManagement/DemoRestTest.Infrastructure/DemoRestTest.Infrastructure.csproj", "Services/BookLoanManagement/DemoRestTest.Infrastructure/"]
RUN dotnet restore "Services/BookLoanManagement/DemoRestTest.API/DemoRestTest.API.csproj"
COPY . .
WORKDIR "/src/Services/BookLoanManagement/DemoRestTest.API"
RUN dotnet build "DemoRestTest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoRestTest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoRestTest.API.dll"]
