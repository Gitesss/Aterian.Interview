FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Interview.Aterian/Interview.Aterian.csproj", "Interview.Aterian/"]
RUN dotnet restore "src/Interview.Aterian/Interview.Aterian.csproj"
COPY . .
WORKDIR "/src/Interview.Aterian"
RUN dotnet build "Interview.Aterian.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.Aterian.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.Aterian.dll"]
