# .NET Minimal API with PostgreSQL and Docker Compose

Bu proje, JSON verilerini anahtar-değer çiftleriyle saklamak için **PostgreSQL** ve **Marten** kullanarak bir .NET Minimal API sunmaktadır. Proje Docker Compose kullanılarak konteynerlerde çalıştırılabilir.

## Proje İçeriği

- **API Projesi**: Anahtar-değer çiftlerini almak, eklemek ve silmek için HTTP isteklerini yöneten Minimal API.
- **Service Projesi**: Veritabanı işlemleri ve iş mantığını yöneten servis katmanı.
- **Docker**: Dockerfile ve docker-compose.yaml dosyaları ile projeyi konteynerlere yerleştirip çalıştırmak.

## Gereksinimler

- **Docker** ve **Docker Compose**: Bu proje, tüm bağımlılıklarıyla birlikte Docker konteynerlarında çalışır. 
  - [Docker'ı Yükleyin](https://docs.docker.com/get-docker/)
  - [Docker Compose'u Yükleyin](https://docs.docker.com/compose/install/)

## Projeyi Çalıştırma

1. **Docker ve Docker Compose'u Yükleyin**: Eğer sisteminizde yüklü değilse, [Docker'ı ve Docker Compose'u](https://docs.docker.com/get-docker/) yükleyin.

2. **Projeyi Klonlayın**:
    ```bash
    git clone https://github.com/kullanici_adiniz/proje_adi.git
    cd proje_adi
    ```

3. **Docker Compose ile Çalıştırın**:
    Projeyi başlatmak için `docker-compose up --build` komutunu çalıştırın. Bu komut Dockerfile'ı kullanarak API'yi ve PostgreSQL servisini çalıştıracak.
    ```bash
    docker-compose up --build
    ```

4. **Uygulamaya Erişim**:
    - API'yi [http://localhost:8080](http://localhost:8080) üzerinden test edebilirsiniz.
    - API'ye GET, POST ve DELETE istekleri göndererek veritabanı işlemlerini test edebilirsiniz.

## API Endpoint'leri

- **GET /{key}**: Belirtilen anahtar için JSON verisini döndürür.
- **POST /{key}**: Belirtilen anahtar ile JSON verisini ekler veya günceller.
- **DELETE /{key}**: Belirtilen anahtara ait veriyi siler.

## Teknolojiler

- **.NET 8 Minimal API**
- **Marten** (PostgreSQL ile JSON verisi için)
- **Docker ve Docker Compose**

## Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakabilirsiniz.
