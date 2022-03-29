#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Kai.Console.Service.Auth/Kai.Console.Service.Auth.csproj", "Microservices/Kai.Console.Service.Auth/"]
RUN dotnet restore "Microservices/Kai.Console.Service.Auth/Kai.Console.Service.Auth.csproj"
COPY . .
WORKDIR "/src/Microservices/Kai.Console.Service.Auth"
RUN dotnet build "Kai.Console.Service.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kai.Console.Service.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kai.Console.Service.Auth.dll"]