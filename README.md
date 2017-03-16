# BmstuLibraryResources
Проект "Ресурс" для библиотеки МГТУ им. Н.Э. Баумана

<h3>Настройка подключения к БД</h3>

Открываем Web.config<br>
<br>
```
<connectionStrings>
    <add name="ConnectionString" connectionString="Data Source=HOME-ПК; Initial Catalog=Library;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>
```
<br>
Меняем значение атрибута <strong>connectionString</strong> на необходимое. 
