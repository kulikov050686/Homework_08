using Homework_08.BaseClasses;
using Homework_08.Models;
using Homework_08.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Homework_08
{
    /// <summary>
    /// Модель представление главного окна
    /// </summary>
    public class MainViewModel : BaseClassINPC
    {
        #region Закрытые поля

        int selected;
        List<Department> companyDepartments;       

        ICommand saveFile;
        ICommand openFile;
        ICommand exit;
        ICommand sortById;
        ICommand sortByAge;
        ICommand sortBySalary;
        ICommand addWorker;
        ICommand addDepartment;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложение
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Список всех департаментов компании
        /// </summary>
        public List<Department> CompanyDepartments
        {
            get
            {
                if(companyDepartments == null)
                {
                    companyDepartments = new List<Department>();
                }

                return companyDepartments;
            }
            set 
            {
                if (companyDepartments == null)
                {
                    companyDepartments = new List<Department>();
                }

                companyDepartments = value;
                OnPropertyChanged("CompanyDepartments");
            }
        }        

        /// <summary>
        /// Команда сохранить в файл
        /// </summary>
        public ICommand SaveFile
        {
            get 
            {
                return saveFile ?? (saveFile = new RelayCommand((obj)=>
                {                    
                    FileDialog.SaveFileDialog(CompanyDepartments);
                }));
            } 
        }

        /// <summary>
        /// Команда открыть файл
        /// </summary>
        public ICommand OpenFile
        {
            get
            {
                return openFile ?? (openFile = new RelayCommand((obj) =>
                {
                    var temp = FileDialog.OpenFileDialog();

                    if (temp != null) 
                    {
                        CompanyDepartments = temp;                        
                    }
                }));
            }
        }

        /// <summary>
        /// Команда закрыть приложение
        /// </summary>
        public ICommand Exit
        {
            get 
            {
                return exit ?? (exit = new RelayCommand((obj) =>
                {                    
                    Application.Current.Shutdown();
                })); 
            }
        }

        /// <summary>
        /// Сортировка листа по идентификатору
        /// </summary>
        public ICommand SortById
        { 
            get 
            {
                return sortById ?? (sortById = new RelayCommand((obj) => 
                {
                    if(CompanyDepartments != null)
                    {
                        if(CompanyDepartments[Selected].Workers != null)
                        {
                            SortList<int>.Sort(CompanyDepartments[Selected].Workers, key => key.Id);                            
                        }
                    }
                })); 
            } 
        }

        /// <summary>
        /// Сортировка листа по возрасту
        /// </summary>
        public ICommand SortByAge
        {
            get 
            {
                return sortByAge ?? (sortByAge = new RelayCommand((obj) => 
                {
                    if (CompanyDepartments != null)
                    {
                        if (CompanyDepartments[Selected].Workers != null)
                        {
                            SortList<int>.Sort(CompanyDepartments[Selected].Workers, key => key.Age);
                        }
                    }
                })); 
            } 
        }

        /// <summary>
        /// Сортировка по зарплате
        /// </summary>
        public ICommand SortBySalary
        {
            get 
            {
                return sortBySalary ?? (sortBySalary = new RelayCommand((obj) => 
                {
                    if (CompanyDepartments != null)
                    {
                        if (CompanyDepartments[Selected].Workers != null)
                        {
                            SortList<int>.Sort(CompanyDepartments[Selected].Workers, key => key.Salary);                            
                        }
                    }                    
                }));
            } 
        }

        /// <summary>
        /// Добавить нового работника
        /// </summary>
        public ICommand AddWorker
        {
            get 
            {
                return addWorker ?? (addWorker = new RelayCommand((obj) => 
                {
                    Worker TempWorker = AddWorkerDialog.Show(companyDepartments[Selected].NameDepartment);

                    if (TempWorker != null)
                    {
                        companyDepartments[Selected].Workers.Add(TempWorker);
                    }
                }));
            } 
        }

        /// <summary>
        /// Добавить новый департамент
        /// </summary>
        public ICommand AddDepartment
        {
            get 
            {
                return addDepartment ?? (addDepartment = new RelayCommand((obj) =>
                {

                }));
            } 
        }

        /// <summary>
        /// Номер вкладки
        /// </summary>
        public int Selected
        {
            get 
            { 
                return selected; 
            }
            set
            {
                selected = value;                
                OnPropertyChanged("Selected");
            }
        }

        #endregion

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            Title = "Приложение";

            List<Worker> list1 = new List<Worker>
            {
                new Worker(26, "Виталий", "Смолинов", 24, "Депортамент 1", "Охранник", 20000),
                new Worker(29, "Семён", "Лопатин", 37, "Депортамент 1", "Программист", 39000),
                new Worker(15, "Михаил", "Липов", 28, "Депортамент 1", "Уборщик", 17000)
            };

            List<Worker> list2 = new List<Worker>
            {
                new Worker(23, "Олег", "Синицин", 45, "Депортамент 2", "Программист", 45000),
                new Worker(27, "Павел", "Муромский", 31, "Депортамент 2", "Программист", 37000),
                new Worker(17, "Леонид", "Алексеев", 35, "Депортамент 2", "Охранник", 15000)
            };

            List<Worker> list3 = new List<Worker>
            {
                new Worker(24, "Александр", "Лидин", 25, "Депортамент 3", "Помощник программиста", 31000),
                new Worker(14, "Леонид", "Стариков", 24, "Депортамент 3", "Помощник программиста", 21000),
                new Worker(35, "Алексей", "Примеров", 21, "Депортамент 3", "Помощник программиста", 35000)
            };


            CompanyDepartments = new List<Department>
            {
                new Department("Депортамент 1", list1),
                new Department("Депортамент 2", list2),
                new Department("Депортамент 3", list3)
            };
        }
    }
}
