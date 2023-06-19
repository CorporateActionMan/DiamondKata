FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Diamond.Console/Diamond.Console.csproj", "Diamond.Console/"]
COPY ["Diamond.Generators/Diamond.Generators.csproj", "Diamond.Generators/"]
COPY ["Diamond.Config/Diamond.Config/Diamond.Config.csproj", "Diamond.Config/Diamond.Config/"]
COPY ["Diamond.Writers/Diamond.Writers.csproj", "Diamond.Writers/"]
RUN dotnet restore "Diamond.Console/Diamond.Console.csproj"
COPY . .
WORKDIR "/src/Diamond.Console"
RUN dotnet build "Diamond.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diamond.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diamond.Console.dll"]
