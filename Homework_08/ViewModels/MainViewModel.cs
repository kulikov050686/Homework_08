using Homework_08.BaseClasses;
using Homework_08.Models;
using Homework_08.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Specialized;
using System;

namespace Homework_08
{
    /// <summary>
    /// Модель представление главного окна
    /// </summary>
    public class MainViewModel : BaseClassINPC
    {
        #region Закрытые поля

        int selectedDepartment;
        int selectedWorker;
        ObservableCollection<Department> companyDepartments;       

        ICommand saveFile;
        ICommand openFile;
        ICommand exit;
        ICommand sortById;
        ICommand sortByAge;
        ICommand sortBySalary;
        ICommand sortByAgeAndSalary;
        ICommand sortDepartmentByName;
        ICommand sortDepartmentByAmountOfWorkers;
        ICommand addWorker;
        ICommand addDepartment;
        ICommand deleteWorker;
        ICommand deleteDepartment;
        ICommand editWorker;
        ICommand editDepartment;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложение
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Список всех департаментов компании
        /// </summary>
        public ObservableCollection<Department> CompanyDepartments
        {
            get
            {
                if(companyDepartments == null)
                {
                    companyDepartments = new ObservableCollection<Department>();
                }

                return companyDepartments;
            }
            set 
            {
                if (companyDepartments == null)
                {
                    companyDepartments = new ObservableCollection<Department>();
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
                }, (obj) => CompanyDepartments.Count != 0));
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
                    if (CompanyDepartments[SelectedDepartment].Workers != null)
                    {
                        SortList<int>.SortWorker(CompanyDepartments[SelectedDepartment].Workers, key => key.Id);
                    }
                }, (obj) => CompanyDepartments.Count != 0)); 
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
                    if (CompanyDepartments[SelectedDepartment].Workers != null)
                    {
                        SortList<int>.SortWorker(CompanyDepartments[SelectedDepartment].Workers, key => key.Age);
                    }                    
                }, (obj) => CompanyDepartments.Count != 0)); 
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
                    if (CompanyDepartments[SelectedDepartment].Workers != null)
                    {
                        SortList<int>.SortWorker(CompanyDepartments[SelectedDepartment].Workers, key => key.Salary);
                    }
                }, (obj) => CompanyDepartments.Count != 0));
            } 
        }

        /// <summary>
        /// Сортировка по возрасту и зарплате
        /// </summary>
        public ICommand SortByAgeAndSalary
        { 
            get 
            {
                return sortByAgeAndSalary ?? (sortByAgeAndSalary = new RelayCommand((obj) =>
                {
                    if (CompanyDepartments[SelectedDepartment].Workers != null)
                    {
                        SortList<int>.SortWorker(CompanyDepartments[SelectedDepartment].Workers, key1 => key1.Age, key2 => key2.Salary);
                    }
                }, (obj) => CompanyDepartments.Count != 0));
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
                    Worker TempWorker = AddWorkerDialog.Show(companyDepartments[SelectedDepartment].NameDepartment);

                    if (TempWorker != null)
                    {
                        companyDepartments[SelectedDepartment].Workers.Add(TempWorker);
                    }                                        
                }, (obj) => CompanyDepartments.Count != 0));
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
                    Department TempDepartment = AddDepartmentDialog.Show();

                    if(TempDepartment != null)
                    {
                        CompanyDepartments.Add(TempDepartment);
                    }
                }));
            } 
        }

        /// <summary>
        /// Сортировка листа департаментов по названию
        /// </summary>
        public ICommand SortDepartmentByName
        {
            get 
            {
                return sortDepartmentByName ?? (sortDepartmentByName = new RelayCommand((obj) => 
                {
                    SortList<string>.SortDepartment(CompanyDepartments, key => key.NameDepartment);
                }, (obj) => CompanyDepartments.Count != 0)); 
            }
        }

        /// <summary>
        /// Сортировка листа департаментов по количеству в нём сотрудников 
        /// </summary>
        public ICommand SortDepartmentByAmountOfWorkers
        {
            get 
            {
                return sortDepartmentByAmountOfWorkers ?? (sortDepartmentByAmountOfWorkers = new RelayCommand((obj) =>
                {
                    SortList<int>.SortDepartment(CompanyDepartments, key => key.AmountOfWorkers);
                }, (obj) => CompanyDepartments.Count != 0)); 
            }
        }

        /// <summary>
        /// Редактирование департамента
        /// </summary>
        public ICommand EditDepartment
        {
            get 
            {
                return editDepartment ?? (editDepartment = new RelayCommand((obj) => 
                {
                    if (MessageBox.Show("Редактировать текущий департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        CompanyDepartments[SelectedDepartment] = EditDepartmentDialog.Show(CompanyDepartments[SelectedDepartment]);                        
                    }

                }, (obj) => CompanyDepartments.Count != 0)); 
            }
        }

        /// <summary>
        /// Редактиование работника
        /// </summary>
        public ICommand EditWorker
        { 
            get 
            {
                return editWorker ?? (editWorker = new RelayCommand((obj) => 
                {
                    MessageBox.Show("Пока не работает!");
                }, (obj) => CompanyDepartments.Count != 0)); 
            } 
        }

        /// <summary>
        /// Удалить работника
        /// </summary>
        public ICommand DeleteWorker
        {
            get 
            {
                return deleteWorker ?? (deleteWorker = new RelayCommand((obj) => 
                {
                    //MessageBox.Show("Пока не работает!");
                    MessageBox.Show(Convert.ToString(SelectedDepartment) + " " + Convert.ToString(SelectedWorker));
                }, (obj) => CompanyDepartments.Count != 0)); 
            } 
        }

        /// <summary>
        /// Удалить департамент
        /// </summary>
        public ICommand DeleteDepartment
        {
            get 
            {
                return deleteDepartment ?? (deleteDepartment = new RelayCommand((obj) => 
                {
                    if(MessageBox.Show("Удалить текущий департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        CompanyDepartments.RemoveAt(SelectedDepartment);
                    }
                }, (obj) => CompanyDepartments.Count != 0)); 
            }
        }

        /// <summary>
        /// Номер вкладки
        /// </summary>
        public int SelectedDepartment
        {
            get 
            { 
                return selectedDepartment; 
            }
            set
            {
                selectedDepartment = value;                
                OnPropertyChanged("SelectedDepartment");
            }
        }

        /// <summary>
        /// Номер сотрудника
        /// </summary>
        public int SelectedWorker
        {
            get
            {
                return selectedWorker;
            }
            set
            {
                selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
            }
        }

        #endregion

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            Title = "Приложение";

            CompanyDepartments.CollectionChanged += CompanyDepartments_CollectionChanged;
        }

        private void CompanyDepartments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }        
    }
}
