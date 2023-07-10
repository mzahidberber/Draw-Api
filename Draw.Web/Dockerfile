#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Draw.Web/Draw.Web.csproj", "Draw.Web/"]
COPY ["Draw.Business/Draw.Business.csproj", "Draw.Business/"]
COPY ["Draw.Core/Draw.Core.csproj", "Draw.Core/"]
COPY ["Draw.Entities/Draw.Entities.csproj", "Draw.Entities/"]
COPY ["Draw.DataAccess/Draw.DataAccess.csproj", "Draw.DataAccess/"]
COPY ["Draw.DrawLayer/Draw.DrawLayer.csproj", "Draw.DrawLayer/"]
RUN dotnet restore "Draw.Web/Draw.Web.csproj"
COPY . .
WORKDIR "/src/Draw.Web"
RUN dotnet build "Draw.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Draw.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Draw.Web.dll"]