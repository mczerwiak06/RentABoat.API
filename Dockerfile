FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

WORKDIR /src/RentABoat.API
RUN dotnet publish RentABoat.API.csproj -c Realase -o /app/publish

FROM build AS tests
WORKDIR /src/RentABoat.Tests
RUN dotnet test

FROM build AS update-database
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef database update --project RentABoat.Infrastructure --startup-project RentABoat.API

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=update-database /src/RentABoat.API/dbo.RentABoat.db .
COPY --from=update-database /app/publish .
ENTRYPOINT ["dotnet", "RentABoat.API.dll"]
