FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Test5.sln" "Test5.sln"

# Applications
COPY "apps/auth-server/src/Test5.AuthServer/Test5.AuthServer.csproj" "apps/auth-server/src/Test5.AuthServer/Test5.AuthServer.csproj"
COPY "apps/public-web/src/Test5.PublicWeb/Test5.PublicWeb.csproj" "apps/public-web/src/Test5.PublicWeb/Test5.PublicWeb.csproj"
COPY *"apps/blazor/src/Test5.Blazor/Test5.Blazor.csproj" "apps/blazor/src/Test5.Blazor/Test5.Blazor.csproj"
COPY *"apps/blazor/src/Test5.Blazor.Server/Test5.Blazor.Server.csproj" "apps/blazor/src/Test5.Blazor.Server/Test5.Blazor.Server.csproj"
COPY *"apps/web/src/Test5.Web/Test5.Web.csproj" "apps/web/src/Test5.Web/Test5.Web.csproj"

# Shared Projects
COPY "shared/Test5.DbMigrator/Test5.DbMigrator.csproj" "shared/Test5.DbMigrator/Test5.DbMigrator.csproj"
COPY "shared/Test5.Shared.Hosting/Test5.Shared.Hosting.csproj" "shared/Test5.Shared.Hosting/Test5.Shared.Hosting.csproj"
COPY "shared/Test5.Shared.Hosting.Gateways/Test5.Shared.Hosting.Gateways.csproj" "shared/Test5.Shared.Hosting.Gateways/Test5.Shared.Hosting.Gateways.csproj"
COPY "shared/Test5.Shared.Hosting.Microservices/Test5.Shared.Hosting.Microservices.csproj" "shared/Test5.Shared.Hosting.Microservices/Test5.Shared.Hosting.Microservices.csproj"
COPY "shared/Test5.Shared.Hosting.AspNetCore/Test5.Shared.Hosting.AspNetCore.csproj" "shared/Test5.Shared.Hosting.AspNetCore/Test5.Shared.Hosting.AspNetCore.csproj"
COPY "shared/Test5.Shared.Hosting/Test5.Shared.Hosting.csproj" "shared/Test5.Shared.Hosting/Test5.Shared.Hosting.csproj"
COPY "shared/Test5.Shared.Localization/Test5.Shared.Localization.csproj" "shared/Test5.Shared.Localization/Test5.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/Test5.AdministrationService.HttpApi.Host/Test5.AdministrationService.HttpApi.Host.csproj" "services/administration/src/Test5.AdministrationService.HttpApi.Host/Test5.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/Test5.IdentityService.HttpApi.Host/Test5.IdentityService.HttpApi.Host.csproj" "services/identity/src/Test5.IdentityService.HttpApi.Host/Test5.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/Test5.SaasService.HttpApi.Host/Test5.SaasService.HttpApi.Host.csproj" "services/saas/src/Test5.SaasService.HttpApi.Host/Test5.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/Test5.ProductService.HttpApi.Host/Test5.ProductService.HttpApi.Host.csproj" "services/product/src/Test5.ProductService.HttpApi.Host/Test5.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/Test5.WebGateway/Test5.WebGateway.csproj" "gateways/web/src/Test5.WebGateway/Test5.WebGateway.csproj"
COPY "gateways/web-public/src/Test5.PublicWebGateway/Test5.PublicWebGateway.csproj" "gateways/web-public/src/Test5.PublicWebGateway/Test5.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "Test5.sln"

COPY . .
WORKDIR "/src/services/saas/src/Test5.SaasService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test5.SaasService.HttpApi.Host.dll"]