#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["elk-logging-demo/elk-logging-demo.csproj", "elk-logging-demo/"]
RUN dotnet restore "elk-logging-demo/elk-logging-demo.csproj"
COPY . .
WORKDIR "/src/elk-logging-demo"
RUN dotnet build "elk-logging-demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "elk-logging-demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "elk-logging-demo.dll"]