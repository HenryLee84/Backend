#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["*.sln", "."]
COPY ["Backend/Backend.csproj", "Backend/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Utilities/Utilities.csproj", "Utilities/"]

RUN dotnet restore

COPY ["Backend/.", "Backend/"]
COPY ["Repository/.", "Repository/"]
COPY ["Utilities/.", "Utilities/"]

RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /src/out .
ENTRYPOINT ["dotnet", "Backend.dll"]
