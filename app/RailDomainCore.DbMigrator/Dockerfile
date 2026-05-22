FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["global.json", "."]
COPY ["RailDomainCore.slnx", "."]
COPY ["src/RailDomainCore.Domain.Shared/RailDomainCore.Domain.Shared.csproj", "src/RailDomainCore.Domain.Shared/"]
COPY ["src/RailDomainCore.Domain/RailDomainCore.Domain.csproj", "src/RailDomainCore.Domain/"]
COPY ["src/RailDomainCore.Application.Contracts/RailDomainCore.Application.Contracts.csproj", "src/RailDomainCore.Application.Contracts/"]
COPY ["src/RailDomainCore.Application/RailDomainCore.Application.csproj", "src/RailDomainCore.Application/"]
COPY ["src/RailDomainCore.EntityFrameworkCore/RailDomainCore.EntityFrameworkCore.csproj", "src/RailDomainCore.EntityFrameworkCore/"]
COPY ["app/RailDomainCore.DbMigrator/RailDomainCore.DbMigrator.csproj", "app/RailDomainCore.DbMigrator/"]
RUN dotnet restore "app/RailDomainCore.DbMigrator/RailDomainCore.DbMigrator.csproj"
COPY . .
RUN dotnet publish "app/RailDomainCore.DbMigrator/RailDomainCore.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RailDomainCore.DbMigrator.dll"]
