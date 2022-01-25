﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using BankModelLibrary;

namespace ServicesLib
{
    public class LogWriter
    {
        /// <summary>
        /// Имя директории и файла
        /// </summary>
        static string
            _logFileName,
            path = System.Environment.CurrentDirectory + @"\logs";

        /// <summary>
        /// Список логов текущей сессии
        /// </summary>
        public static ObservableCollection<string> Logs = new();

        /// <summary>
        /// Флаг сигнализирующий о том что сессия только что запущена
        /// </summary>
        static bool _firstStart = true;

        /// <summary>
        /// Назначает имя файла с логами
        /// </summary>
        private static void SetCurrentLogFileName()
        {
            var now = DateTime.UtcNow;
            _logFileName = $"{(now.Year.ToString())}_{now.Month.ToString()}_{now.Day.ToString()}_log.txt";
            _firstStart = false;
        }

        /// <summary>
        /// создаёт файл
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private static bool CheckFile(string FileName)
        {
            if (!File.Exists(FileName)) File.Create(FileName);
            return true;
        }

        /// <summary>
        /// Проверяет и создаёт каталоги и файлы для логов
        /// </summary>
        /// <param name="EventDescription"></param>
        static void WorkWithLogsPath(string EventDescription)
        {
            string dir = "logs";

            if (_firstStart) SetCurrentLogFileName();
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(Path.Combine(path, _logFileName)))
            {
                using FileStream fs = new(Path.Combine(path, _logFileName), FileMode.Create);
            };
        }

        /// <summary>
        /// Добавляет лог в коллекцию логов текущей сессии
        /// </summary>
        /// <param name="EventDescription"></param>
        private static void AddToLogsList(string EventDescription) =>
            Logs.Add(EventDescription);

        /// <summary>
        /// Записывает лог в файл и выводит его на главной странице
        /// </summary>
        /// <param name="EventDescription"></param>
        public static /*async*/ void WriteToLog(string EventDescription, User user)
        {
            string AddedEventDescription = $"{DateTime.UtcNow} : {EventDescription} : {user}";
            /*await Task.Run(() => */
            WorkWithLogsPath(AddedEventDescription)/*)*/;
            AddToLogsList(AddedEventDescription);

            using (StreamWriter sr = new StreamWriter(Path.Combine(path, _logFileName), true))
            {
                sr.WriteLine(AddedEventDescription);
                sr.Close();
            };
        }
    }
}
