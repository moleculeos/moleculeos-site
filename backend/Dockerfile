FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY ./MoleculeOSSite /app

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

RUN adduser --disabled-password --no-create-home dotnet

WORKDIR /app
COPY --from=build /app/out .

USER dotnet

CMD ["dotnet", "MoleculeOSSite.dll"]