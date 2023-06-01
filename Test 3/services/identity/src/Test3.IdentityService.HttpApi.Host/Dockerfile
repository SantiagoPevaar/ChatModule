FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Test3.sln" "Test3.sln"

# Applications
COPY "apps/auth-server/src/Test3.AuthServer/Test3.AuthServer.csproj" "apps/auth-server/src/Test3.AuthServer/Test3.AuthServer.csproj"
COPY "apps/public-web/src/Test3.PublicWeb/Test3.PublicWeb.csproj" "apps/public-web/src/Test3.PublicWeb/Test3.PublicWeb.csproj"
COPY *"apps/blazor/src/Test3.Blazor/Test3.Blazor.csproj" "apps/blazor/src/Test3.Blazor/Test3.Blazor.csproj"
COPY *"apps/blazor/src/Test3.Blazor.Server/Test3.Blazor.Server.csproj" "apps/blazor/src/Test3.Blazor.Server/Test3.Blazor.Server.csproj"
COPY *"apps/web/src/Test3.Web/Test3.Web.csproj" "apps/web/src/Test3.Web/Test3.Web.csproj"

# Shared Projects
COPY "shared/Test3.DbMigrator/Test3.DbMigrator.csproj" "shared/Test3.DbMigrator/Test3.DbMigrator.csproj"
COPY "shared/Test3.Shared.Hosting/Test3.Shared.Hosting.csproj" "shared/Test3.Shared.Hosting/Test3.Shared.Hosting.csproj"
COPY "shared/Test3.Shared.Hosting.Gateways/Test3.Shared.Hosting.Gateways.csproj" "shared/Test3.Shared.Hosting.Gateways/Test3.Shared.Hosting.Gateways.csproj"
COPY "shared/Test3.Shared.Hosting.Microservices/Test3.Shared.Hosting.Microservices.csproj" "shared/Test3.Shared.Hosting.Microservices/Test3.Shared.Hosting.Microservices.csproj"
COPY "shared/Test3.Shared.Hosting.AspNetCore/Test3.Shared.Hosting.AspNetCore.csproj" "shared/Test3.Shared.Hosting.AspNetCore/Test3.Shared.Hosting.AspNetCore.csproj"
COPY "shared/Test3.Shared.Hosting/Test3.Shared.Hosting.csproj" "shared/Test3.Shared.Hosting/Test3.Shared.Hosting.csproj"
COPY "shared/Test3.Shared.Localization/Test3.Shared.Localization.csproj" "shared/Test3.Shared.Localization/Test3.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/Test3.AdministrationService.HttpApi.Host/Test3.AdministrationService.HttpApi.Host.csproj" "services/administration/src/Test3.AdministrationService.HttpApi.Host/Test3.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/Test3.IdentityService.HttpApi.Host/Test3.IdentityService.HttpApi.Host.csproj" "services/identity/src/Test3.IdentityService.HttpApi.Host/Test3.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/Test3.SaasService.HttpApi.Host/Test3.SaasService.HttpApi.Host.csproj" "services/saas/src/Test3.SaasService.HttpApi.Host/Test3.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/Test3.ProductService.HttpApi.Host/Test3.ProductService.HttpApi.Host.csproj" "services/product/src/Test3.ProductService.HttpApi.Host/Test3.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/Test3.WebGateway/Test3.WebGateway.csproj" "gateways/web/src/Test3.WebGateway/Test3.WebGateway.csproj"
COPY "gateways/web-public/src/Test3.PublicWebGateway/Test3.PublicWebGateway.csproj" "gateways/web-public/src/Test3.PublicWebGateway/Test3.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "Test3.sln"

COPY . .
WORKDIR "/src/services/identity/src/Test3.IdentityService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test3.IdentityService.HttpApi.Host.dll"]