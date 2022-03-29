#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Applications/Kai.Mall.Platform.Web/Kai.Mall.Platform.Web.csproj", "Applications/Kai.Mall.Platform.Web/"]
RUN dotnet restore "Applications/Kai.Mall.Platform.Web/Kai.Mall.Platform.Web.csproj"
COPY . .
WORKDIR "/src/Applications/Kai.Mall.Platform.Web"
RUN dotnet build "Kai.Mall.Platform.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kai.Mall.Platform.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kai.Mall.Platform.Web.dll"]