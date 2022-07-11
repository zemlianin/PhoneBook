# PhoneBook
## Описание проекта
Телефонная книга для сохранения и просмотра контактов
## Описание работы
 Данный проект создан с использованием [WPF](https://docs.microsoft.com/ru-ru/dotnet/desktop/wpf/introduction-to-wpf?view=netframeworkdesktop-4.8) и [postgreSQL](https://www.postgresql.org/). 
 Пользователь может просматривать ранее сохраненные контакты,
 добавлять информацию о них или создавать новые контакты. Вся информация добавляемая пользователем хранится в БД, 
 взаимодействие с кототрой происходит посредствам библиотеки [Npgsql](https://www.npgsql.org/).
## Начала работы
* ### Настройка и Установка БД
  1. Требуется установить [postgreSQL](https://www.postgresql.org/) и [pgadmin](https://www.pgadmin.org/)
  2. В установленном pgadmin требуется создать на localhost БД с именем PhoneBook, где User Id=postgres и Password=1Q2w3e4r5t
  3. Далее в готовой БД требуется создать таблицу, скомпилировав следующий код 
  ```
  CREATE TABLE people  
  (
    first_name text,
    last_name text,
    info text
  );
* ### Запуск приложения
  1. Установить [Visual Studio](https://visualstudio.microsoft.com/ru/) 
  2. Запустить .sln файл приложения
 

 
 
  
 
