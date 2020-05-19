using Homework_08.BaseClasses;
using Homework_08.Models;
using Homework_08.Views;
using System.Windows;
using System.Windows.Input;

namespace Homework_08.ViewModels
{
    /// <summary>
    /// Модель представление окна добавление департамента
    /// </summary>
    public class AddDepartmentViewModel
    {
        #region Закрытые поля

        Department department;
        string nameDepartament;

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
                    if(!string.IsNullOrWhiteSpace(NameDepartament))
                    {
                        Department = new Department(NameDepartament);
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
        /// Департамент
        /// </summary>
        public Department Department { get => department; set => department = value; }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string NameDepartament { get => nameDepartament; set => nameDepartament = value; }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddDepartmentViewModel()
        {
            Department = null;
        }
            
        /// <summary>
        /// Закрывает окно
        /// </summary>
        private void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is WindowAddDepartament)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
