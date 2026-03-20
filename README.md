# FlightBookingSystem
### Опис проєкту
Це Web API для системи бронювання авіаквитків, розроблене на базі **ASP.NET Core 9** та **MS SQL Server**. Проєкт побудований з використанням багатошарової архітектури (**Clean Architecture**) та підходу **Code First**.
---
### Реалізований функціонал (Відповідно до ТЗ)
**Основні вимоги:**
* **Керування рейсами:** Створення, редагування, видалення та перегляд списку рейсів.
* **Детальна інформація:** Перегляд конкретного рейсу з актуальним статусом кожного місця (вільне/заброньоване).
* **Бронювання:** Можливість забронювати одне або кілька місць за один запит.
* **Скасування:** Функціонал скасування існуючого бронювання зі звільненням місць.
* **Історія користувача:** Перегляд списку всіх бронювань поточного авторизованого користувача.
**Додатково реалізовано:**
* **JWT Auth:** Реєстрація та авторизація користувачів з використанням токенів.
* **Рольова модель:**
  * **Адміністратор:** Керування рейсами (доступ до POST, PUT, DELETE).
  * **Користувач:** Перегляд рейсів та здійснення бронювань.
* **Глобальна обробка помилок:** Middleware для Exceptions.
* **Валідація даних:** Перевірка доступності місць та коректності вхідних моделей.
---
### Технічний стек
* **Framework:** ASP.NET Core 9 (Web API)
* **ORM:** Entity Framework Core (Code First)
* **Database:** MS SQL Server
* **Libraries:** AutoMapper, Identity + JWT Authentication
* **Documentation:** Swagger (OpenAPI)
---
### Інструкція із запуску
#### 1. Налаштування бази даних
У файлі `appsettings.json` проєкту **FlightApp.WebApi** змініть рядок підключення:
`"DefaultConnection": "Server=YOUR_SERVER_NAME;Database=FlightDb;Trusted_Connection=True;TrustServerCertificate=True;"`

#### 2. Застосування міграцій
Виконайте команду в терміналі для створення бази даних:
`dotnet ef database update --project FlightApp.Infrastructure --startup-project FlightApp.WebApi`

#### 3. Запуск проєкту
`dotnet run --project FlightApp.WebApi`
*Система автоматично наповнить базу тестовими даними при першому запуску.*
---
### Основні Ендпоінти (API Endpoints)
**Auth (Авторизація)**
* `POST /api/Auth/register` — Реєстрація користувача
* `POST /api/Auth/login` — Вхід та отримання JWT токена

**Flights (Рейси)**
* `GET /api/Flights` — Список усіх рейсів
* `GET /api/Flights/{id}` — Деталі рейсу та статус місць
* `POST /api/Flights` — Створення рейсу (Admin)
* `PUT /api/Flights/{id}` — Редагування рейсу (Admin)
* `DELETE /api/Flights/{id}` — Видалення рейсу (Admin)

**Booking (Бронювання)**
* `POST /api/Booking` — Забронювати місця
* `GET /api/Booking/my` — Список моїх бронювань
* `DELETE /api/Booking/{id}` — Скасувати бронювання
