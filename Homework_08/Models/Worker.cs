﻿using Homework_08.BaseClasses;
using System;

namespace Homework_08.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    ///[Serializable]
    ///
    public class Worker : BaseClassINPC
    {
        int id;
        string firstName;
        string lastName;
        int age;
        string nameDepartment;
        string employeePosition;
        int salary;

        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public int Id
        { 
            get 
            { 
                return id; 
            }
            set 
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        /// <summary>
        /// Имя работника
        /// </summary>
        public string FirstName
        {
            get 
            {
                return firstName; 
            }
            set 
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            } 
        }

        /// <summary>
        /// Фамилия работника
        /// </summary>
        public string LastName
        {
            get 
            { 
                return lastName; 
            } 
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Возраст работника
        /// </summary>
        public int Age
        {
            get 
            {
                return age; 
            }
            set 
            {
                age = value;
                OnPropertyChanged("Age");
            } 
        }

        /// <summary>
        /// Название департамента работника
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
        /// Должность работника
        /// </summary>
        public string EmployeePosition
        {
            get 
            {
                return employeePosition; 
            }
            set 
            {
                employeePosition = value;
                OnPropertyChanged("EmployeePosition");
            } 
        }

        /// <summary>
        /// Зарплата работника
        /// </summary>
        public int Salary
        {
            get 
            {
                return salary; 
            }
            set 
            {
                salary = value;
                OnPropertyChanged("Salary");
            } 
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        private Worker()
        {
        }

        /// <summary>
        /// Конструктор работника
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника </param>
        /// <param name="firstName"> Имя работника </param>
        /// <param name="lastName"> Фамилия работника </param>
        /// <param name="age"> Возраст работника </param>
        /// <param name="nameDepartment"> Название департамента </param>
        /// <param name="employeePosition"> Занимаемая должность </param>
        /// <param name="salary"> Зарплата работника </param>
        public Worker(int id, 
                      string firstName,
                      string lastName,
                      int age,
                      string nameDepartment,
                      string employeePosition,
                      int salary)
        {
            #region Проверка условий ввода

            if(Id < 0)
            {
                throw new ArgumentNullException("Идентификатор сотрудника не может быть меньше нуля!!!", nameof(Id));
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("Имя работника не может быть пустым!!!", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("Фамилия работника не может быть пустой!!!", nameof(lastName));
            }

            if (age < 18 || age > 99)
            {
                throw new ArgumentException("Невозможный возраст работника!!!", nameof(age));
            }

            if(string.IsNullOrWhiteSpace(nameDepartment))
            {
                throw new ArgumentNullException("Название департамента не может быть пустым!!!", nameof(nameDepartment));
            }

            if (string.IsNullOrWhiteSpace(employeePosition))
            {
                throw new ArgumentNullException("Название должности не может быть пустым!!!", nameof(employeePosition));
            }

            if (salary <= 0)
            {
                throw new ArgumentException("Зарплата работника не может быть меньше нуля!!!", nameof(salary));
            }

            #endregion

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            NameDepartment = nameDepartment;
            EmployeePosition = employeePosition;
            Salary = salary;
        }

        /// <summary>
        /// Вывод информации о работнике 
        /// </summary>
        /// <returns> Строковое представление информации </returns>
        public override string ToString()
        {
            return $"{Id, 10} {FirstName,15} {LastName,15} {Age,10} {NameDepartment, 15} {EmployeePosition, 15} {Salary.ToString("## ###"),10} руб.";
        }
    }
}
