FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Test_2.sln" "Test_2.sln"

# Applications
COPY "apps/auth-server/src/Test_2.AuthServer/Test_2.AuthServer.csproj" "apps/auth-server/src/Test_2.AuthServer/Test_2.AuthServer.csproj"
COPY "apps/public-web/src/Test_2.PublicWeb/Test_2.PublicWeb.csproj" "apps/public-web/src/Test_2.PublicWeb/Test_2.PublicWeb.csproj"
COPY *"apps/blazor/src/Test_2.Blazor/Test_2.Blazor.csproj" "apps/blazor/src/Test_2.Blazor/Test_2.Blazor.csproj"
COPY *"apps/blazor/src/Test_2.Blazor.Server/Test_2.Blazor.Server.csproj" "apps/blazor/src/Test_2.Blazor.Server/Test_2.Blazor.Server.csproj"
COPY *"apps/web/src/Test_2.Web/Test_2.Web.csproj" "apps/web/src/Test_2.Web/Test_2.Web.csproj"

# Shared Projects
COPY "shared/Test_2.DbMigrator/Test_2.DbMigrator.csproj" "shared/Test_2.DbMigrator/Test_2.DbMigrator.csproj"
COPY "shared/Test_2.Shared.Hosting/Test_2.Shared.Hosting.csproj" "shared/Test_2.Shared.Hosting/Test_2.Shared.Hosting.csproj"
COPY "shared/Test_2.Shared.Hosting.Gateways/Test_2.Shared.Hosting.Gateways.csproj" "shared/Test_2.Shared.Hosting.Gateways/Test_2.Shared.Hosting.Gateways.csproj"
COPY "shared/Test_2.Shared.Hosting.Microservices/Test_2.Shared.Hosting.Microservices.csproj" "shared/Test_2.Shared.Hosting.Microservices/Test_2.Shared.Hosting.Microservices.csproj"
COPY "shared/Test_2.Shared.Hosting.AspNetCore/Test_2.Shared.Hosting.AspNetCore.csproj" "shared/Test_2.Shared.Hosting.AspNetCore/Test_2.Shared.Hosting.AspNetCore.csproj"
COPY "shared/Test_2.Shared.Hosting/Test_2.Shared.Hosting.csproj" "shared/Test_2.Shared.Hosting/Test_2.Shared.Hosting.csproj"
COPY "shared/Test_2.Shared.Localization/Test_2.Shared.Localization.csproj" "shared/Test_2.Shared.Localization/Test_2.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/Test_2.AdministrationService.HttpApi.Host/Test_2.AdministrationService.HttpApi.Host.csproj" "services/administration/src/Test_2.AdministrationService.HttpApi.Host/Test_2.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/Test_2.IdentityService.HttpApi.Host/Test_2.IdentityService.HttpApi.Host.csproj" "services/identity/src/Test_2.IdentityService.HttpApi.Host/Test_2.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/Test_2.SaasService.HttpApi.Host/Test_2.SaasService.HttpApi.Host.csproj" "services/saas/src/Test_2.SaasService.HttpApi.Host/Test_2.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/Test_2.ProductService.HttpApi.Host/Test_2.ProductService.HttpApi.Host.csproj" "services/product/src/Test_2.ProductService.HttpApi.Host/Test_2.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/Test_2.WebGateway/Test_2.WebGateway.csproj" "gateways/web/src/Test_2.WebGateway/Test_2.WebGateway.csproj"
COPY "gateways/web-public/src/Test_2.PublicWebGateway/Test_2.PublicWebGateway.csproj" "gateways/web-public/src/Test_2.PublicWebGateway/Test_2.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "Test_2.sln"

COPY . .
WORKDIR "/src/services/administration/src/Test_2.AdministrationService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test_2.AdministrationService.HttpApi.Host.dll"]