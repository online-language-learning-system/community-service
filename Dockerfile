
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CommunityService-API/CommunityService-API.csproj", "CommunityService-API/"]
RUN dotnet restore "CommunityService-API/CommunityService-API.csproj"
COPY . .
WORKDIR "/src/CommunityService-API"
RUN dotnet build "CommunityService-API.csproj" -c Release -o /app/build
RUN dotnet publish "CommunityService-API.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CommunityService-API.dll"]
