	����������� �� SQL Lite � ��������� ���� � ���������� �������. 
1. ���������� => ���������� ������������ => SQLite and SQL Server Compact Toolbox => �������.
2. � DevBoard.Server ������������� Microsoft.EntityFrameworkCore.Sqlite � Microsoft.EntityFrameworkCore.Tools.
3. ��������� ����� ���������� ������ � ������� (DbService). 
4. � DbService ������������� Microsoft.EntityFrameworkCore.Sqlite � Microsoft.EntityFrameworkCore.Tools.
5. ��������� � DbService ���� ������ ������ DbModel.cs.
6. � ������������ ������� DbService ��������� DevBoard.Shared.
7. � ������������ ������� � DevBoard.Server ��������� DbServices.
8. � Sturtup.cs � ������ ConfigureServices() ��������� services.AddEntityFrameworkSqlite().AddDbContext<DbModel>();
9. � ������� ���������� ������� nuget ��������� ������� ���������� ����� ��������: AddMigration MigrationName.
10. � ������� ���������� ������� nuget ��������� ������� ���������� ���� ������: Update-Database.