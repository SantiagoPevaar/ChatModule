FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Test4.sln" "Test4.sln"

# Applications
COPY "apps/auth-server/src/Test4.AuthServer/Test4.AuthServer.csproj" "apps/auth-server/src/Test4.AuthServer/Test4.AuthServer.csproj"
COPY "apps/public-web/src/Test4.PublicWeb/Test4.PublicWeb.csproj" "apps/public-web/src/Test4.PublicWeb/Test4.PublicWeb.csproj"
COPY *"apps/blazor/src/Test4.Blazor/Test4.Blazor.csproj" "apps/blazor/src/Test4.Blazor/Test4.Blazor.csproj"
COPY *"apps/blazor/src/Test4.Blazor.Server/Test4.Blazor.Server.csproj" "apps/blazor/src/Test4.Blazor.Server/Test4.Blazor.Server.csproj"
COPY *"apps/web/src/Test4.Web/Test4.Web.csproj" "apps/web/src/Test4.Web/Test4.Web.csproj"

# Shared Projects
COPY "shared/Test4.DbMigrator/Test4.DbMigrator.csproj" "shared/Test4.DbMigrator/Test4.DbMigrator.csproj"
COPY "shared/Test4.Shared.Hosting/Test4.Shared.Hosting.csproj" "shared/Test4.Shared.Hosting/Test4.Shared.Hosting.csproj"
COPY "shared/Test4.Shared.Hosting.Gateways/Test4.Shared.Hosting.Gateways.csproj" "shared/Test4.Shared.Hosting.Gateways/Test4.Shared.Hosting.Gateways.csproj"
COPY "shared/Test4.Shared.Hosting.Microservices/Test4.Shared.Hosting.Microservices.csproj" "shared/Test4.Shared.Hosting.Microservices/Test4.Shared.Hosting.Microservices.csproj"
COPY "shared/Test4.Shared.Hosting.AspNetCore/Test4.Shared.Hosting.AspNetCore.csproj" "shared/Test4.Shared.Hosting.AspNetCore/Test4.Shared.Hosting.AspNetCore.csproj"
COPY "shared/Test4.Shared.Hosting/Test4.Shared.Hosting.csproj" "shared/Test4.Shared.Hosting/Test4.Shared.Hosting.csproj"
COPY "shared/Test4.Shared.Localization/Test4.Shared.Localization.csproj" "shared/Test4.Shared.Localization/Test4.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/Test4.AdministrationService.HttpApi.Host/Test4.AdministrationService.HttpApi.Host.csproj" "services/administration/src/Test4.AdministrationService.HttpApi.Host/Test4.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/Test4.IdentityService.HttpApi.Host/Test4.IdentityService.HttpApi.Host.csproj" "services/identity/src/Test4.IdentityService.HttpApi.Host/Test4.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/Test4.SaasService.HttpApi.Host/Test4.SaasService.HttpApi.Host.csproj" "services/saas/src/Test4.SaasService.HttpApi.Host/Test4.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/Test4.ProductService.HttpApi.Host/Test4.ProductService.HttpApi.Host.csproj" "services/product/src/Test4.ProductService.HttpApi.Host/Test4.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/Test4.WebGateway/Test4.WebGateway.csproj" "gateways/web/src/Test4.WebGateway/Test4.WebGateway.csproj"
COPY "gateways/web-public/src/Test4.PublicWebGateway/Test4.PublicWebGateway.csproj" "gateways/web-public/src/Test4.PublicWebGateway/Test4.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "Test4.sln"

COPY . .
WORKDIR "/src/services/saas/src/Test4.SaasService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test4.SaasService.HttpApi.Host.dll"]