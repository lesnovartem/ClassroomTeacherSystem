# ClassroomTeacherSystem

[![Typing SVG](https://readme-typing-svg.herokuapp.com?color=%2336BCF7&lines=Classroom+Teacher+System)](https://github.com/lesnovartem/ClassroomTeacherSystem)

BD - Скрипт для импорта базы данных в SQL Server.

MobileApp - Мобильное приложение.

ProjectCollege - Desktop программа.

WebCollege - Api.

***
<h2>API</h2>

Нужно в WebCollege обновить модель ADO.NET EDM. Модель находится в папке "Entities".

Для публикации API нужно открыть "Диспетчер служб IIS".
Нажать на "Сайты", "Добавить веб-сайт". 
![alt tag](https://github.com/lesnovartem/Image/blob/main/Image_1.jpg?raw=true)

Пишем имя сайта, выбераем путь к папке API и нажимаем ОК. 
![alt tag](https://github.com/lesnovartem/Image/blob/main/Image_2.jpg?raw=true)

Что бы проверить опубликовался ли API нужно в браузере написать "http://СвойIP/WebCollege" или http://127.0.0.1/WebCollege.
![alt tag](https://github.com/lesnovartem/Image/blob/main/Image_3.jpg?raw=true)

Чтобы проверить вывод из базы данных можно в браузере написать http://СвойIP/WebCollege/api/Students или http://127.0.0.1/WebCollege/api/Students.
![alt tag](https://github.com/lesnovartem/Image/blob/main/Image_4.jpg?raw=true)
***
<h2>MobileApp</h2>

Для мобильного приложения нужно изменить в "Omissions.xaml.cs" на строчке 23 

```
var response = client.DownloadString("http://СвойIP/WebCollege/api/Students");
```

или на

```
var response = client.DownloadString("http://127.0.0.1/WebCollege/api/Students");
```

Также в "OmissionsAdd.xaml.cs" на 36 строчке изменить на 

```
var result = client.UploadString("http://СвойIP/WebCollege/api/Tests", JsonConvert.SerializeObject(_studentOmissions));
```

или на 

```
var result = client.UploadString("http://127.0.0.1/WebCollege/api/Tests", JsonConvert.SerializeObject(_studentOmissions));
```

И в "ListStudent.xaml.cs" на 23 и 39 строчках изменить на 

```
var response = client.DownloadString("http://СвойIP/WebCollege/api/Students");
```

или на

```
var response = client.DownloadString("http://127.0.0.1/WebCollege/api/Students");
```

![alt tag](https://github.com/lesnovartem/Image/blob/main/Image_5.jpg?raw=true)
