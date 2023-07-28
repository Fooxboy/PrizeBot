FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PrizeBot.Application/PrizeBot.Application.csproj", "PrizeBot.Application/"]
RUN dotnet restore "PrizeBot.Application/PrizeBot.Application.csproj"
COPY . .
WORKDIR "/src/PrizeBot.Application"
RUN dotnet build "PrizeBot.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrizeBot.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrizeBot.Application.dll"]
