FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Test1.sln" "Test1.sln"

# Applications
COPY "apps/auth-server/src/Test1.AuthServer/Test1.AuthServer.csproj" "apps/auth-server/src/Test1.AuthServer/Test1.AuthServer.csproj"
COPY "apps/public-web/src/Test1.PublicWeb/Test1.PublicWeb.csproj" "apps/public-web/src/Test1.PublicWeb/Test1.PublicWeb.csproj"
COPY *"apps/blazor/src/Test1.Blazor/Test1.Blazor.csproj" "apps/blazor/src/Test1.Blazor/Test1.Blazor.csproj"
COPY *"apps/blazor/src/Test1.Blazor.Server/Test1.Blazor.Server.csproj" "apps/blazor/src/Test1.Blazor.Server/Test1.Blazor.Server.csproj"
COPY *"apps/web/src/Test1.Web/Test1.Web.csproj" "apps/web/src/Test1.Web/Test1.Web.csproj"

# Shared Projects
COPY "shared/Test1.DbMigrator/Test1.DbMigrator.csproj" "shared/Test1.DbMigrator/Test1.DbMigrator.csproj"
COPY "shared/Test1.Shared.Hosting/Test1.Shared.Hosting.csproj" "shared/Test1.Shared.Hosting/Test1.Shared.Hosting.csproj"
COPY "shared/Test1.Shared.Hosting.Gateways/Test1.Shared.Hosting.Gateways.csproj" "shared/Test1.Shared.Hosting.Gateways/Test1.Shared.Hosting.Gateways.csproj"
COPY "shared/Test1.Shared.Hosting.Microservices/Test1.Shared.Hosting.Microservices.csproj" "shared/Test1.Shared.Hosting.Microservices/Test1.Shared.Hosting.Microservices.csproj"
COPY "shared/Test1.Shared.Hosting.AspNetCore/Test1.Shared.Hosting.AspNetCore.csproj" "shared/Test1.Shared.Hosting.AspNetCore/Test1.Shared.Hosting.AspNetCore.csproj"
COPY "shared/Test1.Shared.Hosting/Test1.Shared.Hosting.csproj" "shared/Test1.Shared.Hosting/Test1.Shared.Hosting.csproj"
COPY "shared/Test1.Shared.Localization/Test1.Shared.Localization.csproj" "shared/Test1.Shared.Localization/Test1.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/Test1.AdministrationService.HttpApi.Host/Test1.AdministrationService.HttpApi.Host.csproj" "services/administration/src/Test1.AdministrationService.HttpApi.Host/Test1.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/Test1.IdentityService.HttpApi.Host/Test1.IdentityService.HttpApi.Host.csproj" "services/identity/src/Test1.IdentityService.HttpApi.Host/Test1.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/Test1.SaasService.HttpApi.Host/Test1.SaasService.HttpApi.Host.csproj" "services/saas/src/Test1.SaasService.HttpApi.Host/Test1.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/Test1.ProductService.HttpApi.Host/Test1.ProductService.HttpApi.Host.csproj" "services/product/src/Test1.ProductService.HttpApi.Host/Test1.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/Test1.WebGateway/Test1.WebGateway.csproj" "gateways/web/src/Test1.WebGateway/Test1.WebGateway.csproj"
COPY "gateways/web-public/src/Test1.PublicWebGateway/Test1.PublicWebGateway.csproj" "gateways/web-public/src/Test1.PublicWebGateway/Test1.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "Test1.sln"

COPY . .
WORKDIR "/src/gateways/web/src/Test1.WebGateway"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test1.WebGateway.dll"]