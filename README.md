Summary - Отчеты, 
Sprav - Справочники
Entity - Таблицы БД и доступ к ним

В папке Summary все наследуется от класса Summary, включая вид винформы и кнопку "Сформировать". В Summary так же есть юазовые методы, используемые в классах-наслдниках. 
Остальные классы в summary являются классами отчетов, которые обрабатывают период формирования отчета, собирают данные с бд и формируют сам отчет. 
Шаблоны отчетов лежат в папке Templates, а конкретно - текстовые константы путей к шаблонам. Шаблоны в формате .docx, ссылка на работу шаблонизатора: https://habr.com/ru/articles/269307/

Само расширение скачивается через NuGet
