FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["MoleculeOSSite.csproj", "."]
RUN dotnet restore "MoleculeOSSite.csproj"
COPY . .

RUN dotnet build "MoleculeOSSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoleculeOSSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

RUN adduser --disabled-password --no-create-home dotnet
USER dotnet

CMD ["dotnet", "MoleculeOSSite.dll"]

