FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/EduVise.Web.Host/EduVise.Web.Host.csproj", "src/EduVise.Web.Host/"]
COPY ["src/EduVise.Web.Core/EduVise.Web.Core.csproj", "src/EduVise.Web.Core/"]
COPY ["src/EduVise.Application/EduVise.Application.csproj", "src/EduVise.Application/"]
COPY ["src/EduVise.Core/EduVise.Core.csproj", "src/EduVise.Core/"]
COPY ["src/EduVise.EntityFrameworkCore/EduVise.EntityFrameworkCore.csproj", "src/EduVise.EntityFrameworkCore/"]
WORKDIR "/src/src/EduVise.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/EduVise.Web.Host", "src/EduVise.Web.Host"]
COPY ["src/EduVise.Web.Core", "src/EduVise.Web.Core"]
COPY ["src/EduVise.Application", "src/EduVise.Application"]
COPY ["src/EduVise.Core", "src/EduVise.Core"]
COPY ["src/EduVise.EntityFrameworkCore", "src/EduVise.EntityFrameworkCore"]
WORKDIR "/src/src/EduVise.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EduVise.Web.Host.dll"]
