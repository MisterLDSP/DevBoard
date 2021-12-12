using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBoard.Shared
{
    public class Work
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WhatsUp { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop => Start.AddMinutes(Duration);
        public int Duration { get; set; }

        #region Строковое представление времени.
        public string GetStartTime()
        {
            string hour = GetTimeWithZero(Start.Hour);
            string minute = GetTimeWithZero(Start.Minute);
            return $"{hour} : {minute}";
        }
        public string GetStopTime()
        {
            string hour = GetTimeWithZero(Stop.Hour);
            string minute = GetTimeWithZero(Stop.Minute);
            return $"{hour} : {minute}";
        }
        public string GetDuration()
        {
            var hour = GetTimeWithZero(Duration / 60);
            var minute = GetTimeWithZero(Duration % 60);
            return $"{hour} : {minute}";
        }
        public static string GetFinishTime(IEnumerable<Work> works)
        {
            int finishTime = 0;
            foreach (var work in works)
            {
                finishTime += work.Duration;
            }
            var hour = GetTimeWithZero(finishTime / 60);
            var minute = GetTimeWithZero(finishTime % 60);
            return $"{hour} : {minute}";
        }
        /// <summary>
        /// Возвращает строку с доминирующим нулем.
        /// </summary>
        /// <param name="time">Число часов или минут.</param>
        /// <returns>Строка с доминирующим нулем.</returns>
        public static string GetTimeWithZero(int time)
        {
            if(time < 10)
            {
                return $"0{time}";
            }
            return $"{time}";
        }

        #endregion

        #region Чтение и запись коллекции работ.

        #endregion

        public static IEnumerable<Work> GetWorks()
        {
            var works = new List<Work>()
            {
                new Work(){
                    Start = new DateTime(2021, 12, 11, 17, 5, 0), 
                    Duration = 17, 
                    Name = "DevBoard", 
                    Description = "Подготовка;", 
                    WhatsUp = "Старт проекта; Макет основной таблицы с заданиями;"},
                new Work(){
                    Start = new DateTime(2021, 12, 11, 20, 5, 0), 
                    Duration = 65, 
                    Name = "DevBoard", 
                    Description = "Ошибки при сборке проекта;", 
                    WhatsUp = "Попытка вынести в кодбихайнд; Переименование основного файла показа работ; Вынес ссылку на доску в меню;" },
                new Work(){
                    Start = new DateTime(2021, 12, 11, 23, 20, 0), 
                    Duration = 34, 
                    Name = "DevBoard", 
                    Description = "Модель данных", 
                    WhatsUp = "Основная модель работы;" },
                new Work(){Start = new DateTime(2021, 12, 12, 11, 47, 0), 
                    Duration = 15, 
                    Name = "DevBoard", 
                    Description = "Добавить колонку для заданий;", 
                    WhatsUp = "Добавление колонки задание; " },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 12, 11, 0), 
                    Duration = 24, 
                    Name = "DevBoard", 
                    Description = "Поправить часы в разметке; Изменить модель отображение времени (с доминирующими нулями)", 
                    WhatsUp = "Убрал перенос текста в колонках с временем;" },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 12, 43, 0), 
                    Duration = 12, 
                    Name = "DevBoard", 
                    Description = "Разобраться с доминирующими нулями во времени;", 
                    WhatsUp = "Активировал метод преобразования DateTime в строковое представление с доминирующими нулями;" },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 13, 22, 0), 
                    Duration = 16, 
                    Name = "DevBoard", 
                    Description = "Исправить меню для стартовой board;", 
                    WhatsUp = "Настроил перевод со стартовой страницы на board;" },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 13, 55, 0), 
                    Duration = 23, 
                    Name = "DevBoard", 
                    Description = "Финишное время;", 
                    WhatsUp = "Добавил в Work метод для возвращения финишного времени коллекции; Разметка таблицы board для фиишного времени; Добавил доминирующие нули в финишное время;" },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 14, 28, 0), 
                    Duration = 17, 
                    Name = "DevBoard", 
                    Description = "Лэйбл для финишного времени board;", 
                    WhatsUp = "Добавил лэйбл в фстолбец с описание того что сделал; Центрировал содержимое по правому краю;" },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 15, 11, 0), 
                    Duration = 11, 
                    Name = "DevBoard", 
                    Description = @"Значок плэй в кнопке действия (подсмотреть значки в менюшке);", 
                    WhatsUp = "добавил значок play в каждую строку; " },
                new Work(){
                    Start = new DateTime(2021, 12, 12, 16, 6, 0),
                    Duration = 13,
                    Name = "DevBoard",
                    Description = @"GIT;",
                    WhatsUp = "Изучение работы с Git в VS; Авторизация и подключение к репозиторию; Проверка сохранения изменний;" },                
                new Work(){
                    Start = new DateTime(2021, 12, 12, 16, 6, 0),
                    Duration = 16,
                    Name = "DevBoard",
                    Description = @"
Подключение БД;
Строку для добавления новой работы;
Сделать enum на все статичные ссылки; 
Сделать принудительный перенос после ';' ;",
                    WhatsUp = "______" },
            };
            return works;
        }
    }
}
