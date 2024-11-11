using System;
using System.Collections.Generic;

namespace ProjectApp
{
    /// <summary>
    /// Клас Project, який моделює інформацію про IT-проєкт.
    /// </summary>
    public class Project
    {
        // Приватні поля
        private string name;
        private string client;
        private DateTime startDate;
        private DateTime endDate;
        private List<string> tasks;

        // Публічні властивості

        /// <summary>
        /// Назва проєкту (для читання і запису).
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Замовник проєкту (для читання і запису).
        /// </summary>
        public string Client
        {
            get { return client; }
            set { client = value; }
        }

        /// <summary>
        /// Дата початку проєкту (тільки для читання).
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
        }

        /// <summary>
        /// Дата завершення проєкту (для читання і запису).
        /// Перевіряється, щоб дата завершення не була раніше дати початку.
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value < startDate)
                    throw new ArgumentException("Дата завершення не може бути раніше дати початку.");
                endDate = value;
            }
        }

        /// <summary>
        /// Список завдань проєкту (для читання і запису).
        /// </summary>
        public List<string> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        // Конструктори
        /// <summary>
        /// Конструктор за замовчуванням.
        /// Ініціалізує рядкові поля пустими рядками, а список завдань - порожнім.
        /// </summary>
        public Project()
        {
            name = string.Empty;
            client = string.Empty;
            startDate = DateTime.Now;
            endDate = DateTime.Now;
            tasks = new List<string>();
        }
        /// <summary>
        /// Параметризований конструктор.
        /// Ініціалізує назву, замовника, дати та порожній список завдань.
        /// </summary>
        /// <param name="name">Назва проєкту</param>
        /// <param name="client">Замовник</param>
        /// <param name="startDate">Дата початку</param>
        /// <param name="endDate">Дата завершення</param>
        public Project(string name, string client, DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("Дата завершення не може бути раніше дати початку.");

            this.name = name;
            this.client = client;
            this.startDate = startDate;
            this.endDate = endDate;
            tasks = new List<string>();
        }
        /// <summary>
        /// Конструктор копіювання.
        /// Створює новий об'єкт Project, копіюючи дані з іншого об'єкта Project.
        /// </summary>
        /// <param name="other">Інший об'єкт Project</param>
        public Project(Project other)
        {
            name = other.name;
            client = other.client;
            startDate = other.startDate;
            endDate = other.endDate;
            tasks = new List<string>(other.tasks);
        }
        // Публічні методи
        /// <summary>
        /// Додає завдання до списку завдань.
        /// </summary>
        /// <param name="task">Завдання</param>
        public void AddTask(string task)
        {
            tasks.Add(task);
        }
        /// <summary>
        /// Видаляє завдання зі списку завдань.
        /// </summary>
        /// <param name="task">Завдання</param>
        public void RemoveTask(string task)
        {
            tasks.Remove(task);
        }

        /// <summary>
        /// Повертає кількість завдань у проєкті.
        /// </summary>
        /// <returns>Кількість завдань</returns>
        public int GetTaskCount()
        {
            return tasks.Count;
        }

        /// <summary>
        /// Виводить інформацію про проєкт: назву, замовника, дати початку та завершення, кількість завдань.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Назва проєкту: {name}");
            Console.WriteLine($"Замовник: {client}");
            Console.WriteLine($"Дата початку: {startDate.ToShortDateString()}");
            Console.WriteLine($"Дата завершення: {endDate.ToShortDateString()}");
            Console.WriteLine($"Кількість завдань: {GetTaskCount()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення проєкту за допомогою параметризованого конструктора
            Project project1 = new Project("Проєкт A", "Клієнт X", new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));

            // Додавання завдань
            project1.AddTask("Розробка архітектури");
            project1.AddTask("Реалізація функціоналу");
            project1.AddTask("Тестування");

            // Виведення інформації про проєкт
            project1.PrintInfo();

            // Видалення завдання
            project1.RemoveTask("Тестування");

            // Виведення інформації після видалення завдання
            Console.WriteLine("\nПісля видалення завдання:");
            project1.PrintInfo();

            // Створення копії проєкту
            Project projectCopy = new Project(project1);
            Console.WriteLine("\nКопія проєкту:");
            projectCopy.PrintInfo();
        }
    }
}
