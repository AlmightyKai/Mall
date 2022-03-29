#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Kai.Mall.Service.Search/Kai.Mall.Service.Search.csproj", "Microservices/Kai.Mall.Service.Search/"]
RUN dotnet restore "Microservices/Kai.Mall.Service.Search/Kai.Mall.Service.Search.csproj"
COPY . .
WORKDIR "/src/Microservices/Kai.Mall.Service.Search"
RUN dotnet build "Kai.Mall.Service.Search.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kai.Mall.Service.Search.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kai.Mall.Service.Search.dll"]