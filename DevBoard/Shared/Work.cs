using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBoard.Shared
{
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(1024)]
        public string Name { get; set; }
        [MaxLength(2048)]
        public string Note { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop => Start.AddMinutes(Duration);
        public int Duration { get; set; }
        public virtual List<Work> SubWorks { get; set; }

        #region Строковое представление времени.
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
                new Work()
                {
                    Start = new DateTime(2021, 12, 11, 17, 5, 0),
                    Duration = 2,
                    Name = "DevBoard"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 11, 17, 5, 0),
                    Duration = 7,
                    Name = "Создать шаблон проекта."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 11, 17, 13, 0),
                    Duration = 10,
                    Name = "Создать макет основной таблицы с заданиями."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 11, 20, 5, 0), 
                    Duration = 55, 
                    Name = "Вынести в кодбихайнд."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 11, 20, 5, 0),
                    Duration = 10,
                    Name = "Вынести ссылку на доску в меню.",
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 11, 23, 20, 0), 
                    Duration = 34, 
                    Name = "Разработать модель данных"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 11, 47, 0), 
                    Duration = 15, 
                    Name = "Добавить колонку для заданий"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 12, 11, 0), 
                    Duration = 10, 
                    Name = "Поправить часы в разметке."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 12, 22, 0),
                    Duration = 26,
                    Name = "Изменить модель отображение времени (с доминирующими нулями)"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 14, 00, 0), 
                    Duration = 16, 
                    Name = "Исправить меню для стартовой board;"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 14, 18, 0), 
                    Duration = 5, 
                    Name = "Добавил в Work метод для возвращения финишного времени коллекции;"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 14, 28, 0),
                    Duration = 11,
                    Name = "Разметка таблицы board для фиишного времени."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 14, 39, 0),
                    Duration = 7,
                    Name = "Добавить доминирующие нули в финишное время"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 14, 47, 0), 
                    Duration = 7, 
                    Name = "Добавить лэйбл в фстолбец с описание того что сделал"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 14, 55, 0),
                    Duration = 10,
                    Name = "Разметка финишного времени"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 15, 11, 0), 
                    Duration = 11, 
                    Name = "Добавить значок play в каждую строку"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 16, 6, 0),
                    Duration = 12,
                    Name = "Изучить основы работы с Git в VS."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 16, 18, 0),
                    Duration = 11,
                    Name = "Авторизация и подключение к репозиторию;"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 16, 29, 0),
                    Duration = 17,
                    Name = "Проверка сохранения изменний."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 17, 1, 0),
                    Duration = 15,
                    Name = "Проверка измений git в эксплорере vs;"
                },                
                new Work()
                {
                    Start = new DateTime(2021, 12, 12, 17, 17, 0),
                    Duration = 22,
                    Name = "Компонент для добавления новой работы;"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 26, 12, 44, 0),
                    Duration = 73,
                    Name = "Сделать отдельный компонент для добавления работ;"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 26, 16, 0, 0),
                    Duration = 177,
                    Name = "Оставить в модели только название работы;"
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 26, 20, 1, 0),
                    Duration = 37,
                    Name = "Форматирование списка работ."
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 29, 18, 18, 0),
                    Duration = 95,
                    Name = "Подключить БД.",
                    Note = "Для подключения БД SqlLite необходимо установить Microsoft.EntityFrameworkCore.Sqlite. Добавляем контекст работы с бд. Устанавливаем пакет Microsoft.EntityFrameworkCore.Tools. В консоли диспетчера пакетов выполняем команду Add-Migration InitialCreate. "
                },
                new Work()
                {
                    Start = new DateTime(2021, 12, 29, 20, 38, 0),
                    Duration = 43,
                    Name = "Подключить БД.",
                    Note = "Снова пробывал подключиться через отдельный сервис."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 1, 14, 1, 0),
                    Duration = 35,
                    Name = "Подключить БД.",
                    Note = "Подлкючил наконец то БД в сервисоном слое. В файлике ReadMe.txt подробно описано как это было."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 6, 11, 39, 0),
                    Duration = 13,
                    Name = "Установить небольшой девелопер SQLite.",
                    Note = "Установил SQLite Developer от SharpSoftwarePlus http://www.sqlitedeveloper.com/download. Версия 4.29(8mb). Нужно проверить операции с бд и через EF и через девелопер."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 6, 12, 23, 0),
                    Duration = 15,
                    Name = "Оптимизация модели Work под EF (прописать аннотации).",
                    Note = "Сделал миграцию и не получилось. Пришлось удалить все ненужное (Works), откатываться и снова делать миграцию и апдэйт."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 6, 16, 30, 0),
                    Duration = 78,
                    Name = "Написать контроллер для работ.",
                    Note = "Написал и подключил api контроллер WorkController. Оттестил только заход в контроллер. Необходимо оттестить добавление новой работы."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 7, 10, 40, 0),
                    Duration = 132,
                    Name = "Протестировать добавление работ в бд.",
                    Note = "Работы добавляются. Немного допилил отображение работ. Сделал новую формочку в таблице для добавления работ. Сделал метод рефреша таблицы. Начал пилить редактирование работ."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 7, 13, 58, 0),
                    Duration = 28,
                    Name = "Разметка основной таблицы.",
                    Note = "Настроил редирект на playwork выбранной работы с основной таблицы. Достал работу для отображения на странице проигрывания работы из бд."
                },
                new Work()
                {
                    Start = new DateTime(2022, 1, 7, 14, 26, 0),
                    Duration = 64,
                    Name = "Написать таймер.",
                    Note = "Скопипастил секундомер, правда назвал таймером. Осталось дописать таймер и назвать секундомером, а то говнокода маловато."
                },
                ////////////////Текущая//////////////////////////////////////////
                new Work()
                {
                    Start = new DateTime(2022, 1, 8, 12, 29, 0),
                    Duration = 0,
                    Name = "Написать таймер.",
                    Note = "Скопипастил секундомер, правда назвал таймером. Осталось дописать таймер и назвать секундомером, а то говнокода маловато."
                },
                /////////////////////////////////////////////////////////////////
                new Work()
                {
                    Start = new DateTime(1, 1, 1, 0, 0, 0),
                    Duration = 0,
                    Name = "Протестировать чтения, обновления и удаления работ из бд."
                },
                new Work()
                {
                    Start = new DateTime(1, 1, 1, 0, 0, 0),
                    Duration = 0,
                    Name = "Отлов ошибок."
                },

                new Work()
                {
                    Start = new DateTime(1, 1, 1, 0, 0, 0),
                    Duration = 0,
                    Name = "Сделать отдельный компонент для добавления работ."
                },
                new Work()
                {
                    Start = new DateTime(1, 1, 1, 0, 0, 0),
                    Duration = 0,
                    Name = "Доработка формы добавления работ."
                },
                new Work()
                {
                    Start = new DateTime(1, 1, 1, 0, 0, 0),
                    Duration = 0,
                    Name = "Сделать enum на все статичные ссылки."
                },
            };
            return works;
        }
    }
}
