# 🏥 Hospital Management System — Mikroservis Mimarisiyle Hastane Yönetim Sistemi

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4.svg)
![Architecture](https://img.shields.io/badge/architecture-Microservices-blue.svg)
![SQL Server](https://img.shields.io/badge/database-SQL%20Server-CC2927.svg)
![PostgreSQL](https://img.shields.io/badge/database-PostgreSQL-336791.svg)
![MongoDB](https://img.shields.io/badge/database-MongoDB-47A248.svg)

## Genel Bakış

**ASP.NET Core 9** ile geliştirilen, doktor/hastane randevu yönetimine
odaklanan bir mikroservis projesi. Her servis kendi veritabanına ve kendi
sorumluluk alanına sahiptir; bunların üstüne bir MVC web arayüzü (`WebUI`)
oturacak.

## İçindekiler

- [Mimari](#mimari)
- [Teknoloji Yığını](#teknoloji-yığını)
- [Proje Yapısı](#proje-yapısı)
- [Gereksinimler](#gereksinimler)
- [Kurulum ve Çalıştırma](#kurulum-ve-çalıştırma)
- [Durum](#durum)
- [Notlar](#notlar)

## Mimari

| Servis | Sorumluluk | Veritabanı |
|---|---|---|
| `IdentityService` | Kimlik doğrulama, yetkilendirme, kullanıcı hesapları (JWT) | SQL Server |
| `AppointmentService` | Randevular ve randevu detayları | SQL Server |
| `PrescriptionService` | Reçeteler | PostgreSQL |
| `DoctorService` | Doktor profilleri ve lokasyonları | MongoDB |
| `BranchService` | Hastane şubeleri | MongoDB |
| `ReviewService` | Doktor değerlendirmeleri | MongoDB |
| `WebUI` | Kullanıcıya açık MVC frontend'i (henüz varsayılan scaffold; servislere bağlanmıyor) | - |

Şu an için bir API gateway veya konteyner orkestrasyonu yok; her servis
geliştirme aşamasında bağımsız olarak çalıştırılıyor.

## Teknoloji Yığını

- **.NET 9 / ASP.NET Core** (Web API + MVC)
- **Entity Framework Core** — SQL Server ve PostgreSQL (Npgsql) sağlayıcıları
- Doküman tabanlı servisler için **MongoDB.Driver**
- Entity/DTO dönüşümleri için **AutoMapper**
- **JWT Bearer Authentication** (`IdentityService`)
- API dokümantasyonu için **Scalar**

## Proje Yapısı

```
HospitalManagementSystem/
├── Microservices/
│   ├── HospitalManagementSystem.IdentityService
│   ├── HospitalManagementSystem.AppointmentService
│   ├── HospitalManagementSystem.PrescriptionService
│   ├── HospitalManagementSystem.DoctorService
│   ├── HospitalManagementSystem.BranchService
│   └── HospitalManagementSystem.ReviewService
└── Frontends/
    └── HospitalManagementSystem.WebUI
```

## Gereksinimler

- **.NET 9 SDK**
- **SQL Server** (erişilebilir bir instance) — `IdentityService`, `AppointmentService`
- **PostgreSQL** (erişilebilir bir instance) — `PrescriptionService`
- **MongoDB** (erişilebilir bir instance) — `DoctorService`, `BranchService`, `ReviewService`

## Kurulum ve Çalıştırma

Bağlantı bilgileri `appsettings.json`'da değil, her servisin kendi
[`dotnet user-secrets`](https://learn.microsoft.com/aspnet/core/security/app-secrets)
kaydında tutulur (her projede bir `UserSecretsId` tanımlı) —
`appsettings.json`'daki ilgili alanlar bilerek boş bırakılmıştır.

| Servis | user-secrets anahtarı |
|---|---|
| `IdentityService` | `ConnectionStrings:DefaultConnection` |
| `AppointmentService` | `DatabaseSettingsKey:ConnectionString` |
| `PrescriptionService` | `ConnectionStrings:PostgreConnection` |
| `DoctorService` | `DatabaseSettingsKey:ConnectionString`, `DatabaseSettingsKey:DatabaseName`, `DatabaseSettingsKey:DoctorCollectionName` |
| `BranchService` | `DatabaseSettingsKey:ConnectionString`, `DatabaseSettingsKey:DatabaseName`, `DatabaseSettingsKey:BranchCollectionName` |
| `ReviewService` | `DatabaseSettingsKey:ConnectionString`, `DatabaseSettingsKey:DatabaseName`, `DatabaseSettingsKey:ReviewCollectionName` |

Bir servisi lokalde çalıştırmak için:

```bash
cd Microservices/HospitalManagementSystem.<ServiceName>
dotnet user-secrets set "<anahtar>" "<değer>"
dotnet restore
dotnet run
```

Entity Framework Core kullanan servisler (`IdentityService`,
`AppointmentService`, `PrescriptionService`) ilk çalıştırmadan önce migration
gerektirir:

```bash
dotnet ef database update
```

## Durum

Geliştirme sürüyor — servisler adım adım oluşturuluyor (bkz. commit
geçmişi / branch'ler).

## Notlar

Proje, [ASP.NET Core Mikroservis Mimarisi - Doccure Hastane Sistemi](https://www.udemy.com/course/aspnet-core-mikroservis-mimarisi-doccure-hastane-sistemi/)
kursu temel alınarak başlatıldı; kurs materyalinin üzerine zaman içinde
ek özellikler ve düzenlemeler ekleniyor.
