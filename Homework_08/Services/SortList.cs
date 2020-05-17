using Homework_08.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_08.Services
{
    /// <summary>
    /// Сортировка
    /// </summary>
    public static class SortList<T>
    {
        static List<Worker> TempList;

        /// <summary>
        /// Сортировка листа
        /// </summary>
        /// <param name="list"> Сортируемый лист </param>
        /// <param name="key"> Критерий сортировки </param>
        static public void Sort(List<Worker> list, Func<Worker, T> key)
        {
            TempList = new List<Worker>();
            IEnumerable<Worker> e = list.OrderBy(key);

            TempList.Clear();

            foreach (Worker my in e)
            {
                TempList.Add(my);
                list.Remove(my);
            }

            foreach (Worker my in TempList)
            {
                list.Add(my);
            }
        }
    }
}
