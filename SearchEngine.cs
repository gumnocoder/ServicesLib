﻿using System.Collections.ObjectModel;
using BankModelLibrary;
using BankModelLibrary.Interfaces;

namespace ServicesLib
{
    public class SearchEngine
    {
        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <returns></returns>
        public static T SearchByName<T>(ObservableCollection<T> TargetList, string Name) where T : Person
        {
            T t = default;

            if (TargetList != null && TargetList.Count > 0)
            {
                foreach (T element in TargetList)
                {
                    if (element.Name.ToLower() == Name.ToLower())
                    { return element; }
                }
            }
            return t;
        }

        /// <summary>
        /// Поиск по идентификатору
        /// </summary>
        /// <param name="ID">идентификатор</param>
        /// <returns></returns>
        public static T SearchByID<T>(ObservableCollection<T> TargetList, long ID) where T : IIdentificable
        {
            T t = default;

            if (TargetList != null && TargetList.Count > 0)
            {
                foreach (T element in TargetList)
                {
                    if (element.ID == ID)
                    { return element; }
                }
            }
            return t;
        }
    }
}
