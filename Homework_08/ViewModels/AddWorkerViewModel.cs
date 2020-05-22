using Homework_08.BaseClasses;
using Homework_08.Models;
using Homework_08.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Homework_08.ViewModels
{
    /// <summary>
    /// Модель представление окна добавление работника
    /// </summary>
    public class AddWorkerViewModel
    {
        #region Закрытые поля

        Worker worker;
        string idWorker;
        string firstNameWorker;
        string lastNameWorker;
        string ageWorker;
        string employeePositionWorker;
        string salaryWorker;
        string department;
        string addText;

        int id;
        int age;
        int salary;

        ICommand add;
        ICommand cancel;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Добавить
        /// </summary>
        public ICommand Add
        {
            get 
            {
                return add ?? (add = new RelayCommand((obj) => 
                {
                    if(CheckId() && 
                       CheckAge() && 
                       CheckSalary() && 
                       CheckFirstName() && 
                       CheckLastName() && 
                       CheckEmployeePositionWorker())
                    {
                        Worker = new Worker(id, firstNameWorker, lastNameWorker, age, department, employeePositionWorker, salary);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных!!!");
                    }
                })); 
            } 
        }

        /// <summary>
        /// Отменить
        /// </summary>
        public ICommand Cancel
        { 
            get 
            {
                return cancel ?? (cancel = new RelayCommand((obj) => 
                {
                    Close();
                })); 
            } 
        }

        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public string IdWorker { get => idWorker; set => idWorker = value; }

        /// <summary>
        /// Имя работника
        /// </summary>
        public string FirstNameWorker { get => firstNameWorker; set => firstNameWorker = value; }

        /// <summary>
        /// Фамилия работника
        /// </summary>
        public string LastNameWorker { get => lastNameWorker; set => lastNameWorker = value; }

        /// <summary>
        /// Возраст работника
        /// </summary>
        public string AgeWorker { get => ageWorker; set => ageWorker = value; }

        /// <summary>
        /// Должность работника
        /// </summary>
        public string EmployeePositionWorker { get => employeePositionWorker; set => employeePositionWorker = value; }

        /// <summary>
        /// Зарплата работника
        /// </summary>
        public string SalaryWorker { get => salaryWorker; set => salaryWorker = value; }

        /// <summary>
        /// Работник
        /// </summary>
        public Worker Worker { get => worker; private set => worker = value; }

        /// <summary>
        /// Надпись на кнопке добавить
        /// </summary>
        public string AddText { get => addText; set => addText = value; }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="department"> Название департамента </param>
        public AddWorkerViewModel(string department)
        {
            this.department = department;

            if(string.IsNullOrWhiteSpace(this.department))
            {                
                throw new ArgumentNullException("Название департамента не может быть пустым!!!", nameof(this.department));
            }

            Worker = null;
        }

        /// <summary>
        /// Закрывает окно
        /// </summary>
        private void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is WindowAddWorker)
                {
                    window.Close();
                    break;
                }
            }
        }

        #region Проверка ввода данных

        /// <summary>
        /// Проверка ввода данных идентификатора работника
        /// </summary>       
        private bool CheckId()
        {
            if(int.TryParse(IdWorker, out id))
            {
                if(id >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка ввода данных возраста работника
        /// </summary>        
        private bool CheckAge()
        {
            if (int.TryParse(AgeWorker, out age))
            {
                if (18 <= age && age < 99)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка ввода данных зарплаты работника
        /// </summary>
        /// <returns></returns>
        private bool CheckSalary()
        {
            if (int.TryParse(SalaryWorker, out salary))
            {
                if (salary >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка ввода данных имени работника
        /// </summary>        
        private bool CheckFirstName()
        {
            if(!string.IsNullOrWhiteSpace(FirstNameWorker))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка ввода данных фамилии работника
        /// </summary>        
        private bool CheckLastName()
        {
            if(!string.IsNullOrWhiteSpace(LastNameWorker))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка ввода данных должности работника
        /// </summary>        
        private bool CheckEmployeePositionWorker()
        {
            if(!string.IsNullOrWhiteSpace(EmployeePositionWorker))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
