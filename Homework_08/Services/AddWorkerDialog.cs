using Homework_08.Models;
using Homework_08.ViewModels;
using Homework_08.Views;

namespace Homework_08.Services
{
    /// <summary>
    /// Открытие диалогового окна добавить работника
    /// </summary>
    public static class AddWorkerDialog
    {
        /// <summary>
        /// Диалоговое окно для добавления сотрудника
        /// </summary>
        /// <param name="departament"> Название департамента </param>
        public static Worker Show(string department)
        {
            WindowAddWorker addWorker = new WindowAddWorker();
            AddWorkerViewModel addWorkerViewModel = new AddWorkerViewModel(department);

            addWorkerViewModel.Title = "Добавить работника";
            addWorker.DataContext = addWorkerViewModel;

            addWorker.ShowDialog();

            return addWorkerViewModel.Worker;
        }
    }
}
