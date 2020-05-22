using Homework_08.Models;
using Homework_08.ViewModels;
using Homework_08.Views;

namespace Homework_08.Services
{
    /// <summary>
    /// Открытие диалогового окна для редактирования работника
    /// </summary>
    public static class EditWorkerDialog
    {
        /// <summary>
        /// Диалоговое окно для редактирования работника
        /// </summary>        
        public static Worker Show(Worker worker)
        {
            if(worker != null)
            {
                WindowAddWorker addWorker = new WindowAddWorker();
                AddWorkerViewModel addWorkerViewModel = new AddWorkerViewModel(worker.NameDepartment);

                addWorkerViewModel.Title = "Редактировать работника";
                addWorkerViewModel.AddText = "Изменить";
                addWorkerViewModel.IdWorker = worker.Id.ToString();
                addWorkerViewModel.FirstNameWorker = worker.FirstName;
                addWorkerViewModel.LastNameWorker = worker.LastName;
                addWorkerViewModel.AgeWorker = worker.Age.ToString();
                addWorkerViewModel.EmployeePositionWorker = worker.EmployeePosition;
                addWorkerViewModel.SalaryWorker = worker.Salary.ToString();
                addWorker.DataContext = addWorkerViewModel;

                addWorker.ShowDialog();

                if(addWorkerViewModel.Worker != null)
                {
                    worker.Id = int.Parse(addWorkerViewModel.IdWorker);
                    worker.FirstName = addWorkerViewModel.FirstNameWorker;
                    worker.LastName = addWorkerViewModel.LastNameWorker;
                    worker.Age = int.Parse(addWorkerViewModel.AgeWorker);
                    worker.EmployeePosition = addWorkerViewModel.EmployeePositionWorker;
                    worker.Salary = int.Parse(addWorkerViewModel.SalaryWorker);
                }
            }

            return worker;
        }
    }
}
