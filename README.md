# Personal Blogging Platform API

A simple REST API to create, read, update and delete blog articles.  
Blog məqalələri yaratmaq, oxumaq, yeniləmək və silmək üçün sadə REST API.

---

## Features / Xüsusiyyətlər

- Full CRUD support for blog articles.  
  Blog məqalələri üçün tam CRUD dəstəyi.

- Validates article fields (title, content, author) before saving.  
  Saxlamazdan əvvəl məqalə sahələrini (başlıq, məzmun, müəllif) yoxlayır.

- Integrated Swagger UI for easy API exploration.  
  API-ni asanlıqla araşdırmaq üçün inteqrasiya edilmiş Swagger UI.

---

## What I Learned / Öyrəndiklərim

- How to write API endpoints without Controllers (Minimal API).  
  Controller-siz API endpoint-ləri necə yazılır (Minimal API).

- How to connect to a database and do CRUD operations with Entity Framework Core.  
  Entity Framework Core ilə bazaya qoşulub CRUD əməliyyatları necə edilir.

- How to use async/await when talking to the database.  
  Bazaya sorğu göndərəndə async/await necə istifadə olunur.

- How to check if the user's input is valid before saving it.  
  İstifadəçidən gələn məlumatı saxlamazdan əvvəl necə yoxlamaq olar.

- How to return the right HTTP status codes (like 201 for created, 404 for not found).  
  Düzgün HTTP status kodlarını necə qaytarmaq olar (məsələn 201 - yaradıldı, 404 - tapılmadı).

---

## Tech Stack / Texnologiyalar

C#, ASP.NET Core, Entity Framework Core, SQL Server

---

## Endpoints

| Method | URL | Description |
|--------|-----|-------------|
| POST | `/articles` | Creates a new article. / Yeni məqalə yaradır. |
| GET | `/articles` | Returns all articles. / Bütün məqalələri qaytarır. |
| GET | `/articles/{id}` | Returns a specific article. / Müəyyən məqaləni qaytarır. |
| PUT | `/articles/{id}` | Updates a specific article. / Müəyyən məqaləni yeniləyir. |
| DELETE | `/articles/{id}` | Deletes a specific article. / Müəyyən məqaləni silir. |

### Example Response / Nümunə Cavab

```json
{
  "id": 1,
  "title": "My First Post",
  "content": "Hello, world!",
  "author": "İsmayıl",
  "createdAt": "2026-07-01T10:00:00"
}
```

---

## Setup / Quraşdırma

1. Clone the repository.  
   Repozitorini kopyalayın.

2. Make sure SQL Server LocalDB is installed.  
   SQL Server LocalDB-nin quraşdırıldığına əmin olun.

3. Apply the database migrations.  
   Veritabanı miqrasiyalarını tətbiq edin.
    
    `dotnet ef database update`

4. Run the project.  
   Proyekti işə salın.

    `dotnet run`
