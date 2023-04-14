

## ScheduleTest
Arkaplan işlemlerini yürütmemizi ve yönetmemizi sağlamak amacı ile Hangfire kütüphanesini tercih ettim. 
Handfire database işlemleri için PostgreSql tercih edildi. 

## Hazırlık

- Visual Studio 2022 yada JetBrains Rider
- NET 7.0
- PostgreSql (Ben Docker Containerı Tercih ettim)

## Gerekli Paketler
- Hangfire
- Hangfire.PostgreSql (Sql Storage)

## Configuration

```bash
  services.AddHangfire(x => x.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));
  services.AddHangfireServer();
```