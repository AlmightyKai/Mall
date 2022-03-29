#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Kai.Mall.Service.Order/Kai.Mall.Service.Order.csproj", "Microservices/Kai.Mall.Service.Order/"]
RUN dotnet restore "Microservices/Kai.Mall.Service.Order/Kai.Mall.Service.Order.csproj"
COPY . .
WORKDIR "/src/Microservices/Kai.Mall.Service.Order"
RUN dotnet build "Kai.Mall.Service.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kai.Mall.Service.Order.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kai.Mall.Service.Order.dll"]