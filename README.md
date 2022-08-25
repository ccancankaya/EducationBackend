EducationBackend

- appsettings dosyasında veritabanı bağlantısı stringi kontrol edilmeli / database oluşturulmalı
- aşağıda ki komutlar ile migrations yapılmalı :
      
dotnet ef migrations add migration_1 --project DataAccess !! DataAccess içinde migrations varsa aşağıda ki yeterli
dotnet ef database update --project DataAccess

