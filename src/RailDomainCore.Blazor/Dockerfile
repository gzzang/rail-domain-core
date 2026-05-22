FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["global.json", "."]
COPY ["RailDomainCore.slnx", "."]
COPY ["src/RailDomainCore.Domain.Shared/RailDomainCore.Domain.Shared.csproj", "src/RailDomainCore.Domain.Shared/"]
COPY ["src/RailDomainCore.Domain/RailDomainCore.Domain.csproj", "src/RailDomainCore.Domain/"]
COPY ["src/RailDomainCore.Application.Contracts/RailDomainCore.Application.Contracts.csproj", "src/RailDomainCore.Application.Contracts/"]
COPY ["src/RailDomainCore.Application/RailDomainCore.Application.csproj", "src/RailDomainCore.Application/"]
COPY ["src/RailDomainCore.EntityFrameworkCore/RailDomainCore.EntityFrameworkCore.csproj", "src/RailDomainCore.EntityFrameworkCore/"]
COPY ["src/RailDomainCore.Blazor/RailDomainCore.Blazor.csproj", "src/RailDomainCore.Blazor/"]
RUN dotnet restore "src/RailDomainCore.Blazor/RailDomainCore.Blazor.csproj"
COPY . .
RUN dotnet publish "src/RailDomainCore.Blazor/RailDomainCore.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "RailDomainCore.Blazor.dll"]
