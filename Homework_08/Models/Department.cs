using Homework_08.BaseClasses;
using System;
using System.Collections.ObjectModel;

namespace Homework_08.Models
{
    /// <summary>
    /// Департамент
    /// </summary>
    public class Department : BaseClassINPC
    {
        string date;
        string nameDepartment;
        ObservableCollection<Worker> workers;
        int amountOfWorkers;

        /// <summary>
        /// Дата создания депортамента
        /// </summary>
        public string Date
        {
            get 
            { 
                return date; 
            }
            set 
            { 
                date = value;
                OnPropertyChanged("Date");
            }
        }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string NameDepartment
        {
            get
            {
                return nameDepartment;
            }
            set 
            { 
                nameDepartment = value;
                OnPropertyChanged("NameDepartment");
            }
        }

        /// <summary>
        /// Количество работников депорматента
        /// </summary>
        public int AmountOfWorkers
        { 
            get
            {
                if(workers == null)
                {
                    return 0;
                }

                return workers.Count;
            }
            set
            {
                if(workers == null)
                {
                    amountOfWorkers = 0;
                }
                else
                {
                    amountOfWorkers = workers.Count;
                }

                OnPropertyChanged("AmountOfWorkers");
            }
        }

        /// <summary>
        /// Работники департамента
        /// </summary>
        public ObservableCollection<Worker> Workers
        { 
            get
            {
                if (workers == null)
                {
                    workers = new ObservableCollection<Worker>();
                }

                return workers;
            }
            set 
            {
                if(workers == null)
                {
                    workers = new ObservableCollection<Worker>();
                }

                workers = value;
                OnPropertyChanged("Workers");
            } 
        }        

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        private Department()
        {            
        }

        /// <summary>
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameDepartment"> Название департамента </param>
        /// <param name="workers"> Список работников департамента </param>
        public Department(string nameDepartment, ObservableCollection<Worker> workers = null)
        {
            if (string.IsNullOrWhiteSpace(nameDepartment))
            {
                throw new ArgumentNullException("Название департамента не может быть пустым!!!", nameof(nameDepartment));
            }          
            
            if(workers != null)
            {
                AmountOfWorkers = workers.Count;
            }
            else
            {
                AmountOfWorkers = 0;
            }

            date = DateTime.Now.ToString("dd:MM:yyyy");
            NameDepartment = nameDepartment;
            Workers = workers;
        }

        /// <summary>
        /// Вывод информации о депортаменте
        /// </summary>        
        public override string ToString()
        {
            return NameDepartment;
        }
    }
}
