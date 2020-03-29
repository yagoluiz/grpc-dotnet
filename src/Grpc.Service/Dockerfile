FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Grpc.Service/Grpc.Service.csproj", "src/Grpc.Service/"]
RUN dotnet restore "src/Grpc.Service/Grpc.Service.csproj"
COPY . .
WORKDIR "/src/src/Grpc.Service"
RUN dotnet build "Grpc.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Grpc.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Grpc.Service.dll"]
