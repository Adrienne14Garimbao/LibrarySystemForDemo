FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/LibrarySystemForDemo.Web.Mvc/LibrarySystemForDemo.Web.Mvc.csproj", "src/LibrarySystemForDemo.Web.Mvc/"]
COPY ["src/LibrarySystemForDemo.Web.Core/LibrarySystemForDemo.Web.Core.csproj", "src/LibrarySystemForDemo.Web.Core/"]
COPY ["src/LibrarySystemForDemo.Application/LibrarySystemForDemo.Application.csproj", "src/LibrarySystemForDemo.Application/"]
COPY ["src/LibrarySystemForDemo.Core/LibrarySystemForDemo.Core.csproj", "src/LibrarySystemForDemo.Core/"]
COPY ["src/LibrarySystemForDemo.EntityFrameworkCore/LibrarySystemForDemo.EntityFrameworkCore.csproj", "src/LibrarySystemForDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystemForDemo.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystemForDemo.Web.Mvc", "src/LibrarySystemForDemo.Web.Mvc"]
COPY ["src/LibrarySystemForDemo.Web.Core", "src/LibrarySystemForDemo.Web.Core"]
COPY ["src/LibrarySystemForDemo.Application", "src/LibrarySystemForDemo.Application"]
COPY ["src/LibrarySystemForDemo.Core", "src/LibrarySystemForDemo.Core"]
COPY ["src/LibrarySystemForDemo.EntityFrameworkCore", "src/LibrarySystemForDemo.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystemForDemo.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystemForDemo.Web.Mvc.dll"]
