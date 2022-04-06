#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Applications/Almighty.Mall.Seller.Web/Almighty.Mall.Seller.Web.csproj", "Applications/Almighty.Mall.Seller.Web/"]
RUN dotnet restore "Applications/Almighty.Mall.Seller.Web/Almighty.Mall.Seller.Web.csproj"
COPY . .
WORKDIR "/src/Applications/Almighty.Mall.Seller.Web"
RUN dotnet build "Almighty.Mall.Seller.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Almighty.Mall.Seller.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Almighty.Mall.Seller.Web.dll"]