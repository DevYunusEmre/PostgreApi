# 1. Çalışma zamanı (runtime) imajı
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. Build ortamı için .NET SDK imajı
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 3. Proje dosyalarını kopyala
COPY ["MiniMalApi.PostgreSQL/MiniMalApi.PostgreSQL.csproj", "MiniMalApi.PostgreSQL/"]
COPY ["Business/Business.csproj", "Business/"]

# 4. Restore bağımlılıkları
RUN dotnet restore "MiniMalApi.PostgreSQL/MiniMalApi.PostgreSQL.csproj"

# 5. Tüm kaynak kodlarını kopyala
COPY . .

# 6. Build işlemi
WORKDIR "/src/MiniMalApi.PostgreSQL"
RUN dotnet build "MiniMalApi.PostgreSQL.csproj" -c Release -o /app/build

# 7. Yayınlama işlemi
FROM build AS publish
RUN dotnet publish "MiniMalApi.PostgreSQL.csproj" -c Release -o /app/publish

# 8. Çalışma zamanı için final imaj
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniMalApi.PostgreSQL.dll"]

# 9. Kestrel konfigürasyonu
# Docker konteyneri içinde 8080 portunda dinleme yapması için bu kodu ekleyebilirsiniz
# Bu, .NET Core uygulamanızın 8080 portunu dinlemesini sağlar.
ENV ASPNETCORE_URLS=http://+:8080
