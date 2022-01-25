﻿using System.Collections.ObjectModel;
using System.IO;
using BankModelLibrary;
using Newtonsoft.Json;
using static BankModelLibrary.Bank;
using static BankModelLibrary.ClientList<BankModelLibrary.Client>;
using static BankModelLibrary.UserList<BankModelLibrary.User>;

namespace ServicesLib
{
    public static class DataSaver<T>
    {
        public static void DataSaverChain()
        {
            DataSaver<User>.JsonSeralize(UserList<User>.UsersList, UsersPath);
            DataSaver<Client>.JsonSeralize(ClientList<Client>.ClientsList, ClientsPath);
            DataSaver<BankAccount>.JsonSeralize(ThisBank.Credits, ThisBank.CreditsPath);
            DataSaver<BankAccount>.JsonSeralize(ThisBank.Debits, ThisBank.DebitsPath);
            DataSaver<BankAccount>.JsonSeralize(ThisBank.Deposits, ThisBank.DepositsPath);
            new BankSettingsSaver(ThisBank);
        }

        /// <summary>
        /// удаляет файл перед сохранением, во избежание ошибок
        /// </summary>
        /// <param name="outputFile"></param>
        private static void DeleteIfExists(string outputFile)
        {
            //string pathToFile = Path.Combine(Environment.CurrentDirectory + @"\" + outputFile);
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
        }

        /// <summary>
        /// выполняет сериализацию
        /// </summary>
        /// <param name="serializibleObject">сериализуемый обьект</param>
        /// <param name="path">выходной файл</param>
        public static void JsonSeralize(ObservableCollection<T> serializibleObject, string path)
        {
            DeleteIfExists(path);
            string json = JsonConvert.SerializeObject(serializibleObject);
            File.WriteAllText(path, json);
        }
    }
}
