FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RentABoat.API/RentABoat.API.csproj", "RentABoat.API/"]
RUN dotnet restore "RentABoat.API/RentABoat.API.csproj"
COPY . .
WORKDIR "/src/RentABoat.API"
RUN dotnet build "RentABoat.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentABoat.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentABoat.API.dll"]
