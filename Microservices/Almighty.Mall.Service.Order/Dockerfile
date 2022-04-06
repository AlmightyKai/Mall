#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Almighty.Mall.Service.Order/Almighty.Mall.Service.Order.csproj", "Microservices/Almighty.Mall.Service.Order/"]
RUN dotnet restore "Microservices/Almighty.Mall.Service.Order/Almighty.Mall.Service.Order.csproj"
COPY . .
WORKDIR "/src/Microservices/Almighty.Mall.Service.Order"
RUN dotnet build "Almighty.Mall.Service.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Almighty.Mall.Service.Order.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Almighty.Mall.Service.Order.dll"]