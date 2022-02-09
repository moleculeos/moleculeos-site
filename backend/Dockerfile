FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MoleculeOSSite/MoleculeOSSite.csproj", "MoleculeOSSite/"]
RUN dotnet restore "MoleculeOSSite/MoleculeOSSite.csproj"
COPY . .
WORKDIR "/src/MoleculeOSSite"
RUN dotnet build "MoleculeOSSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoleculeOSSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoleculeOSSite.dll"]