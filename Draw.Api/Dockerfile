#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Draw.Api/Draw.Api.csproj", "Draw.Api/"]
COPY ["Draw.Business/Draw.Business.csproj", "Draw.Business/"]
COPY ["Draw.Core/Draw.Core.csproj", "Draw.Core/"]
COPY ["Draw.DataAccess/Draw.DataAccess.csproj", "Draw.DataAccess/"]
COPY ["Draw.DrawLayer/Draw.DrawLayer.csproj", "Draw.DrawLayer/"]
COPY ["Draw.Entities/Draw.Entities.csproj", "Draw.Entities/"]
RUN dotnet restore "Draw.Api/Draw.Api.csproj"
COPY . .
WORKDIR "/src/Draw.Api"
RUN dotnet build "Draw.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Draw.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Draw.Api.dll"]

# RUN ls
# RUN cd Draw.DataAccess2
# RUN dotnet ef migrations add init
# RUN dotnet ef database update