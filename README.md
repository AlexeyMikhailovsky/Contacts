# Contact Manager
 Веб-приложение для управления списком контактов с поддержкой CRUD-операций.  
**Backend**: ASP.NET Core 8, Entity Framework Core (PostgreSQL).  
**Frontend**: HTML, CSS, Bootstrap 5, jQuery.
## Запуск проекта

### Требования
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

Настройте строку подключения - отредактируйте appsettings.json:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=contactsdb;Username=postgres;Password=yourpassword"
  }
}
```
Примените миграции и запустите.
## Функционал
Главная страница
![logo](https://github.com/AlexeyMikhailovsky/Contacts/blob/69486a15742b8596d9416375545bc65de0a4aa65/docs/MainPage.png)
Форма добавления
![logo](https://github.com/AlexeyMikhailovsky/Contacts/blob/69486a15742b8596d9416375545bc65de0a4aa65/docs/AddPopup.png)
Предупреждение о необходимых полях
![logo](https://github.com/AlexeyMikhailovsky/Contacts/blob/69486a15742b8596d9416375545bc65de0a4aa65/docs/Requirements.png)
Удаление
![logo](https://github.com/AlexeyMikhailovsky/Contacts/blob/69486a15742b8596d9416375545bc65de0a4aa65/docs/DeletePopup.png)
Сообщение об ошибке
![logo](https://github.com/AlexeyMikhailovsky/Contacts/blob/69486a15742b8596d9416375545bc65de0a4aa65/docs/ErrPopup.png)