FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LibrarySystemForDemo.Web.Host/LibrarySystemForDemo.Web.Host.csproj", "src/LibrarySystemForDemo.Web.Host/"]
COPY ["src/LibrarySystemForDemo.Web.Core/LibrarySystemForDemo.Web.Core.csproj", "src/LibrarySystemForDemo.Web.Core/"]
COPY ["src/LibrarySystemForDemo.Application/LibrarySystemForDemo.Application.csproj", "src/LibrarySystemForDemo.Application/"]
COPY ["src/LibrarySystemForDemo.Core/LibrarySystemForDemo.Core.csproj", "src/LibrarySystemForDemo.Core/"]
COPY ["src/LibrarySystemForDemo.EntityFrameworkCore/LibrarySystemForDemo.EntityFrameworkCore.csproj", "src/LibrarySystemForDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystemForDemo.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystemForDemo.Web.Host", "src/LibrarySystemForDemo.Web.Host"]
COPY ["src/LibrarySystemForDemo.Web.Core", "src/LibrarySystemForDemo.Web.Core"]
COPY ["src/LibrarySystemForDemo.Application", "src/LibrarySystemForDemo.Application"]
COPY ["src/LibrarySystemForDemo.Core", "src/LibrarySystemForDemo.Core"]
COPY ["src/LibrarySystemForDemo.EntityFrameworkCore", "src/LibrarySystemForDemo.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystemForDemo.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystemForDemo.Web.Host.dll"]
