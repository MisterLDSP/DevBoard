	Подключение БД SQL Lite в сервисном слое к серверному проекту. 
1. Расширения => Управление расширениями => SQLite and SQL Server Compact Toolbox => Скачать.
2. В DevBoard.Server устанавливаем Microsoft.EntityFrameworkCore.Sqlite и Microsoft.EntityFrameworkCore.Tools.
3. Добавляем новую консольный проект в решение (DbService). 
4. В DbService устанавливаем Microsoft.EntityFrameworkCore.Sqlite и Microsoft.EntityFrameworkCore.Tools.
5. Добавляем в DbService файл модели данных DbModel.cs.
6. В зависимостях проекта DbService добавляем DevBoard.Shared.
7. В зависимостях проекта к DevBoard.Server добавялем DbServices.
8. В Sturtup.cs в методе ConfigureServices() добавляем services.AddEntityFrameworkSqlite().AddDbContext<DbModel>();
9. В консоли диспетчера пакетов nuget выполняем команду добавления новой миграции: AddMigration MigrationName.
10. В консоли диспетчера пакетов nuget выполняем команду обновления базы данных: Update-Database.