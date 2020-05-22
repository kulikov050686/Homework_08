using Homework_08.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Homework_08.Services
{
    /// <summary>
    /// Сортировка
    /// </summary>
    public static class SortList<T>
    {        
        /// <summary>
        /// Сортировка листа работников
        /// </summary>
        /// <param name="list"> Сортируемый лист </param>
        /// <param name="key"> Критерий сортировки </param>
        static public void SortWorker(ObservableCollection<Worker> list, Func<Worker, T> key1, Func<Worker, T> key2 = null)
        {
            ObservableCollection<Worker> TempList = new ObservableCollection<Worker>();
            IEnumerable<Worker> e;

            if(key2 != null)
            {
                e = list.OrderBy(key1).ThenBy(key2);
            }
            else
            {
                e = list.OrderBy(key1);
            }

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

        /// <summary>
        /// Сортировка листа департаментов
        /// </summary>
        /// <param name="list"> Сортируемый лист </param>
        /// <param name="key"> Критерий сортировки </param>
        static public void SortDepartment(ObservableCollection<Department> list, Func<Department, T> key)
        {
            ObservableCollection<Department> TempList = new ObservableCollection<Department>();
            IEnumerable<Department> e = list.OrderBy(key);

            TempList.Clear();

            foreach (Department my in e)
            {
                TempList.Add(my);
                list.Remove(my);
            }

            foreach (Department my in TempList)
            {
                list.Add(my);
            }
        }
    }
}
